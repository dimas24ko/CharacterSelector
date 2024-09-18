using System.Collections.Generic;
using Contexts;
using StateMachine.States;

namespace StateMachine {
    public class AppStateMachine {
        private Dictionary<StateType, IState> States { get; }
        private IState CurrentState { get; set; }
        
        public AppStateMachine(GlobalContext globalContext) {
            States = new Dictionary<StateType, IState>();
            AddState(StateType.Game, new GameState(TransitionToState, globalContext));
            AddState(StateType.Loading, new LoadingState(TransitionToState, globalContext));
            AddState(StateType.Lobby, new LobbyState(TransitionToState, globalContext));
        }
        
        //if we have only linear transitions, i can add a dictionary of transitions
        //and then call TransitionToNext(StateType stateType) to change the state
        //but i like more agile way of switching states
        public void TransitionToState(StateType stateType) {
            if (CurrentState != null) {
                CurrentState.Exit();
            }
            
            CurrentState = States[stateType];
            CurrentState.Enter();
        }
        
        private void AddState(StateType stateType, IState state) {
            States.Add(stateType, state);
        }
    }
}
