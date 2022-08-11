using UnityEngine;

namespace Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 axis
        {
            get
            {
                Vector2 _axis = JoystickGetAxis;
                if (_axis == Vector2.zero)
                    _axis = UnityAxis;
                return _axis;
            }
        }

        private static Vector2 UnityAxis => 
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}
