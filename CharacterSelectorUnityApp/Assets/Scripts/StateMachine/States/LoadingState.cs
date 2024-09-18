using System;
using Contexts;
using UnityEngine.SceneManagement;

namespace StateMachine.States {
    public class LoadingState : IState {
        private const string LoadingSceneName = "LoadingScene";

        private readonly Action<StateType> _exitAction;
        private readonly GlobalContext _globalContext;

        public LoadingState(Action<StateType> exitAction, GlobalContext globalContext) {
            _exitAction = exitAction;
            _globalContext = globalContext;
        }

        public void Enter() {
            SceneManager.LoadScene(LoadingSceneName);
            _globalContext.AssetManager.OnAssetsLoadSuccess += OnLoadingComplete;
            _globalContext.AssetManager.LoadAllAssets();
        }

        public void Exit() {
            _globalContext.AssetManager.OnAssetsLoadSuccess -= OnLoadingComplete;
            SceneManager.UnloadSceneAsync(LoadingSceneName);
        }

        //ToDo: add minimal delay if loading is too fast if needed
        private void OnLoadingComplete() {
            _exitAction(StateType.Lobby);
        }
    }
}
