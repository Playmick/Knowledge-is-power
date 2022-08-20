using Scripts.Infrastructure.States;
using Scripts.Logic;
using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Infrastructure
{
    internal class Game
    {
        public GameStateMachine stateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }

        
    }
}