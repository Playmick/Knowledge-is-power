using UnityEngine;

namespace Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Button = "Fire";

        public abstract Vector2 axis { get; } 
            
        
        public bool isAttackButtonUp() => 
            SimpleInput.GetButtonUp(Button);

        protected static Vector2 JoystickGetAxis =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
