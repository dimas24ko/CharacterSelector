using System;
using Contexts;
using Services.CharacterFactory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Object = UnityEngine.Object;

namespace StateMachine.States {
    public class GameState : IState {
        private const string GameSceneName = "GameScene";

        private readonly Action<StateType> _exitAction;
        private readonly GlobalContext _globalContext;

        private CharacterEntity _characterEntity;

        private GameView _view;

        public GameState(Action<StateType> exitAction, GlobalContext globalContext) {
            _exitAction = exitAction;
            _globalContext = globalContext;
        }

        public void Enter() {
            AsyncOperation loadSceneTask = SceneManager.LoadSceneAsync(GameSceneName);

            loadSceneTask.completed += _ => {
                OnGameSceneLoaded();
            };
        }

        public void Exit() {
            _characterEntity.DestroyView();

            UnbindEvents();
            SceneManager.UnloadSceneAsync(GameSceneName);
        }

        private void OnGameSceneLoaded() {
            _view = Object.FindObjectOfType<GameView>();

            CreateGameScene();

            BindEvents();
        }

        private void CreateGameScene() {
            _characterEntity = _globalContext.CharacterFactory.CreateCharacter(_globalContext.SelectedCharacter,
                _view.characterContainer);
        }

        private void BindEvents() {
            _view.backToLobbyButton.onClick.AddListener(OnBackToLobbyButtonClick);
        }

        private void OnBackToLobbyButtonClick() {
            _exitAction(StateType.Lobby);
        }

        private void UnbindEvents() {
            _view.backToLobbyButton.onClick.RemoveListener(OnBackToLobbyButtonClick);
        }
    }
}
