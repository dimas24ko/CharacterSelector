using System;
using System.Collections.Generic;
using Contexts;
using Services.CharacterFactory;
using Services.CharacterRandomizer;
using Services.CharacterSelector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Object = UnityEngine.Object;

namespace StateMachine.States {
    public class LobbyState : IState {
        private const string LobbySceneName = "LobbyScene";

        private readonly Action<StateType> _exitAction;
        private readonly GlobalContext _globalContext;

        private ICharacterSelectStrategy _characterSelector;
        private LobbyView _view;
        private CharacterEntity _characterEntity;

        public LobbyState(Action<StateType> exitAction, GlobalContext globalContext) {
            _exitAction = exitAction;
            _globalContext = globalContext;
        }

        //ToDo: think about abstract class, not interface
        public void Enter() {
            AsyncOperation loadSceneTask = SceneManager.LoadSceneAsync(LobbySceneName);

            loadSceneTask.completed += _ => {
                OnLobbySceneLoaded();
            };
        }

        public void Exit() {
            UnbindEvents();
            SceneManager.UnloadSceneAsync(LobbySceneName);
        }

        private void OnLobbySceneLoaded() {
            _view = Object.FindObjectOfType<LobbyView>();

            List<string> allCharacters = _globalContext.AssetManager.GetAllCharacters();
            var characterRandomizer = new SimpleRandomCharacterGetter(allCharacters);
            _characterSelector = new RandomCharacterSelector(characterRandomizer);

            CreateCharacter();

            BindEvents();
        }

        private void BindEvents() {
            _view.startGameButton.onClick.AddListener(OnStartGameButtonClick);
            _view.generateButton.onClick.AddListener(OnGenerateButtonClick);
        }

        private void UnbindEvents() {
            _view.startGameButton.onClick.RemoveListener(OnStartGameButtonClick);
            _view.generateButton.onClick.RemoveListener(OnGenerateButtonClick);
        }

        private void OnGenerateButtonClick() {
            string newCharacter = _characterSelector.GetNextCharacter();
            _globalContext.SetSelectedCharacter(newCharacter);

            CreateCharacter();
        }

        private void CreateCharacter() {
            if (_characterEntity != null) {
                _characterEntity.DestroyView();
            }

            if (string.IsNullOrEmpty(_globalContext.SelectedCharacter)) {
                return;
            }

            _characterEntity = _globalContext.CharacterFactory.CreateCharacter(_globalContext.SelectedCharacter,
                _view.characterContainer);
        }

        private void OnStartGameButtonClick() {
            if (_globalContext.SelectedCharacter == null) {
                return;
            }

            _exitAction(StateType.Game);
        }
    }
}
