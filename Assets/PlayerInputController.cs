using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    PlayerInput playerInput;

    public Vector2 lookAround;

    public Vector2 steering;
    public bool brake;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();

        playerInput.Map1.Brake.started += context => brake = true;
        playerInput.Map1.Brake.performed+= context => brake = true;
        playerInput.Map1.Brake.canceled+= context => brake = false;
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
}
