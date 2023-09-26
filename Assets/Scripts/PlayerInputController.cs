using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, PlayerInput.IMap1Actions , InputInterface
{
    public delegate void Fire();
    public Fire fire;

    public delegate void Aim();
    public Aim aim;


    PlayerInput playerInput;

    public Vector2 lookAround;

    public Vector2 steering;


    void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Map1.SetCallbacks(this);
        playerInput.Enable();

    }

    private void OnDisable()
    {
        playerInput.Disable();
    }


    public void OnSteering(InputAction.CallbackContext context)
    {
        steering = playerInput.Map1.Steering.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        lookAround = playerInput.Map1.Aim.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            if (fire != null)
            {
                fire();
            }
        }
    }


    public void OnLaser(InputAction.CallbackContext context)
    {
        if(aim != null)
        {
            aim();
        }
    }

    public void OnAction1(InputAction.CallbackContext context)
    {

    }

    public void OnAction2(InputAction.CallbackContext context)
    {

    }

    public Vector2 GetSteering()
    {
        return steering;
    }
}
