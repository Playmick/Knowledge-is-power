using UnityEngine;
using Scripts.Infrastructure;
using Scripts.Services.Input;
using Scripts.CameraLogic;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        private Camera _camera;
        private IInputService _inputService;

        private Vector3 _movementVector;

        private void Start()
        {
            _camera = Camera.main;
            _inputService = Game.inputService;
            CameraFollow();
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

        private void CameraFollow() => 
            _camera.GetComponent<CameraFollow>().Follow(gameObject);

        
    }
}

