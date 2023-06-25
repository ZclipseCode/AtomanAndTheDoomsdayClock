using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : BeatEmUpMovement
{
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Movement.performed += OnMove;
        controls.Player.Movement.canceled += OnMoveCanceled;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        Move(context.ReadValue<Vector2>());
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        StopMove();
    }

    private void OnDestroy()
    {
        controls.Disable();
        controls.Player.Movement.performed -= OnMove;
        controls.Player.Movement.canceled -= OnMoveCanceled;
    }
}
