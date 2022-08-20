using System;
using Scripts.Services.Input;
using UnityEngine;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.AssetManagement;
using Scripts.Services.PersistentProgress;

namespace Scripts.Infrastructure.States
{
    //стартовое состояние
    //мы создали InitialScene
    //этот класс кидает нас в сцену Initial
    //после нее переносит State Machine в следующее состояние
    public class BootState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServicesBase _services;

        public BootState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = ServicesBase.instance;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }
        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>("Main");

        private void RegisterServices()
        {
            _services.CreateService<IInputService>(RegisterInputService());
            _services.CreateService<IAssets>(new AssetProvider());
            _services.CreateService<IPersistentProgressService>(new PersistentProgressService());
            _services.CreateService<IGameFactory>(new GameFactory(assets: _services.GetService<IAssets>()));
        }
        private IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }

}
