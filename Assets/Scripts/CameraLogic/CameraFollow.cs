using UnityEngine;
using System.Collections;


namespace Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        public float rotationAngleX;
        public float distance;
        
        [SerializeField] private float _offsetY;
        [SerializeField] private Transform _following;
        private Vector3 _followingPosition;
        private Vector3 _position;
        private Quaternion _rotation;

        private void LateUpdate()
        {
            if (_following == null)
                return;

            _rotation = Quaternion.Euler(rotationAngleX, 0, 0);

            FollowingPointPosition();

            transform.rotation = _rotation;
            transform.position = _position;
        }

        public void Follow(GameObject following) =>
            _following = following.transform;

        private void FollowingPointPosition()
        {
            _followingPosition = _following.position;
            _followingPosition.y += _offsetY;
            _position = _rotation * new Vector3(0, 0, -distance) + _followingPosition;
        }
    }
}

