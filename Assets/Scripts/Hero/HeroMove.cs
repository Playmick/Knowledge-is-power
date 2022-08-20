using UnityEngine;
using Scripts.Services.Input;
using Scripts.Infrastructure.Services;
using Scripts.Data;
using Scripts.Services.PersistentProgress;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        private Camera _camera;
        private IInputService _inputService;

        private Vector3 _movementVector;

        public void LoadProgress(PlayerProgress progress)
        {
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.worldData.position = transform.position;
        }

        private void Start()
        {
            _camera = Camera.main;
            _inputService = ServicesBase.instance.GetService<IInputService>();
        }

        private void Update()
        {
            _movementVector = Vector3.zero;

            if (_inputService.axis.sqrMagnitude > Constants.epsilon)
            {
                _movementVector = _camera.transform.TransformDirection(_inputService.axis);
                _movementVector.y = 0;
                _movementVector.Normalize();

                transform.forward = _movementVector;
            }

            _movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * _movementVector * Time.deltaTime);
        }
    }
}

