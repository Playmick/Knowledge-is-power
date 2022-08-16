using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Infrastructure
{
    internal class Game
    {
        public static IInputService inputService;
        public GameStateMachine stateMachine;

        public Game()
        {
            stateMachine = new GameStateMachine();
        }

        
    }
}