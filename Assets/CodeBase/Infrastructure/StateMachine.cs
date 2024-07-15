using Assets.Scripts.Infrastructure.States;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.Infrastructure
{
    public abstract class StateMachine
    {
        protected Dictionary<Type, IExitableState> _states;
        protected IExitableState _currentState;

        public TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            IPayLoadedState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        protected TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }
    }
}
