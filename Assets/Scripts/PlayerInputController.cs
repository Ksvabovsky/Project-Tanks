using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public delegate void RightTrigger();
    public static RightTrigger rightTrigger;

    public delegate void LeftTrigger();
    public static LeftTrigger leftTrigger;


    PlayerInput playerInput;

    public Vector2 lookAround;

    public Vector2 steering;
    public bool brake;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();

        playerInput.Map1.Fire.performed += rTrigger;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        steering = playerInput.Map1.Steering.ReadValue<Vector2>();
        lookAround = playerInput.Map1.Aim.ReadValue<Vector2>();
    }

    public void rTrigger(InputAction.CallbackContext context)
    {
        if (rightTrigger != null)
        {
            rightTrigger();
        }
    }
    public void lTrigger(InputAction.CallbackContext context)
    {
        if(leftTrigger != null)
        {
            leftTrigger();
        }
    }
}
