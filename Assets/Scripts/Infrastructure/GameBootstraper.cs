using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstraper : MonoBehaviour
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game();
            _game.stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}

