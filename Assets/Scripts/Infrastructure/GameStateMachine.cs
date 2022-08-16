using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>();
            _states.Add(typeof(BootstrapState), new BootstrapState(this));
        }
        public void Enter<TState>() where TState : IState
        {
            //нам нужно знать текущее состояние(загрузка, игровой цикл, выход из игры)
            //у каждого состояния есть вход и выход

            //выходим из активного состояния
            _activeState?.Exit();

            //входим в новое состояние
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
        
    }

}
