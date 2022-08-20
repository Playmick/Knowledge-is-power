using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Services.Input
{
    interface IInputService : IService
    {
        Vector2 axis { get;}

        bool isAttackButtonUp();
    }
}
