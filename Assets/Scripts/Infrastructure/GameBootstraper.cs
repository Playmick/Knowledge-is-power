using Scripts.Infrastructure.States;
using Scripts.Logic;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain curtain;
        private Game _game;
        private void Awake()
        {
            _game = new Game(this, curtain);
            _game.stateMachine.Enter<BootState>();

            DontDestroyOnLoad(this);
        }
    }
}

