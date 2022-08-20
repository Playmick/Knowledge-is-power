using Scripts.CameraLogic;
using UnityEngine;
using Scripts.Logic;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services;

namespace Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private LoadingCurtain _curtain;
        private IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
            //как только сцена загрузится, мы готовы туда выпускать героя
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            _gameFactory = ServicesBase.instance.GetService<IGameFactory>(); 

            GameObject hero = _gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));

            _gameFactory.CreateHud();

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }
        private void CameraFollow(GameObject hero) =>
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        

    }
}
