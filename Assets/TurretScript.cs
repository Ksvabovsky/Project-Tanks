using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretScript : MonoBehaviour
{
    [SerializeField]
    GameObject Turret;

    [SerializeField]
    PlayerInputController input;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    Vector3 rotation;

    [SerializeField]
    float rotationSpeed;

    public Vector3 Local;
    public Vector3 global;

    [SerializeField]
    float diff;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Local = Turret.transform.localRotation.eulerAngles;
        global = Turret.transform.rotation.eulerAngles;


        rotation = playerController.lookTransform.eulerAngles;
        // destined rotation in player viewing direction

        diff = Mathf.DeltaAngle(Turret.transform.rotation.eulerAngles.y, rotation.y);
        // angle difference

        float rotTime = Mathf.Abs(diff) / rotationSpeed;
        // time to rotate

        Quaternion target = Quaternion.Lerp(Quaternion.Euler(0f,Turret.transform.rotation.eulerAngles.y,0f), Quaternion.Euler( 0f, rotation.y,0f), Time.deltaTime / rotTime);
        // current target rotation in linear rotation of turret to designeted angle
        
        Turret.transform.rotation = Quaternion.Euler(target.eulerAngles);

        Turret.transform.localRotation = Quaternion.Euler(0f, Turret.transform.localEulerAngles.y, 0f);
        // setting turret in correct rotation of vehicle

    }

    public void SetInput(PlayerInputController controller)
    {
        input = controller;
    }

    public void SetController(PlayerController controller)
    {
        playerController = controller;
    }



}
