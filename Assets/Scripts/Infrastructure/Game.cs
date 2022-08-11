using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Infrastructure
{
    internal class Game
    {
        public static IInputService inputService;

        public Game()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
                inputService = new StandaloneInputService();
            else
                inputService = new MobileInputService();
        }
    }
}