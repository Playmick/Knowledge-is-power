using Scripts.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _states = new Dictionary<Type, IExitableState>();
            _states.Add(typeof(BootState), new BootState(this, sceneLoader));
            _states.Add(typeof(LoadLevelState), new LoadLevelState(this, sceneLoader, curtain));
            _states.Add(typeof(GameLoopState), new GameLoopState(this));
        }
        public void Enter<TState>() where TState : class, IState
        {
            //нам нужно знать текущее состояние(загрузка, игровой цикл, выход из игры)
            //у каждого состояния есть вход и выход

            //выходим из активного состояния
            _activeState?.Exit();

            //входим в новое состояние
            IState state = GetState<TState>();
            _activeState = state;
            state.Enter();
        }
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            _activeState?.Exit();
            IPayloadedState<TPayload> state = GetState<TState>();
            _activeState = state;
            state.Enter(payload);
        }
        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}
