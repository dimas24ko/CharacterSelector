using UnityEngine;

namespace Bootstraps {
    public class AppBootstrap : MonoBehaviour {
        private void Awake() {
            var globalContext = new Contexts.GlobalContext();
            globalContext.InstallBindings();
            globalContext.StateMachine.TransitionToState(StateMachine.StateType.Loading);
        }
    }
}
