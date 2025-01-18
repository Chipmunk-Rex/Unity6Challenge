using Chipmunk.Library;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static Controls;

public class PlayerInputReader : ScriptableSingleton<PlayerInputReader>, IPlayerActions
{
    public UnityEvent OnDashEvent;
    public UnityEvent OnJumpEvent;
    public SerializeableNotifyValue<int> MoveValue;
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDashEvent.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveValue.Value = (int)context.ReadValue<float>();
    }
}
