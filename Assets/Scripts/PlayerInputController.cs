using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public delegate void Fire();
    public Fire fire;

    public delegate void Aim();
    public Aim aim;

    public delegate void ChangeColorNext();
    public ChangeColorNext changeColorNext;

    public delegate void ChangeColorPrevious();
    public ChangeColorPrevious changeColorPrevious;


    public Vector2 lookAround;

    public Vector2 steering;


    void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        //playerInput.Disable();
    }


    public void OnSteering(InputAction.CallbackContext context)
    {
        steering = context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        lookAround = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (fire != null)
            {
                fire();
            }
        }
    }

    public void onDeviceLost(InputAction.CallbackContext context) {
        Debug.Log("chuj");
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

    public void OnColorChangeNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            changeColorNext?.Invoke();
        }

    }
    public void OnColorChangePrevious(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            changeColorPrevious?.Invoke();
        }

    }
}
