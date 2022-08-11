using UnityEngine;

namespace Scripts.Services.Input
{
    interface IInputService
    {
        Vector2 axis { get;}

        bool isAttackButtonUp();
    }
}
