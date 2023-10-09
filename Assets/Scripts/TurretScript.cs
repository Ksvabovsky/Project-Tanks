using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretScript : MonoBehaviour
{
    [SerializeField]
    Transform Turret;
    [SerializeField]
    Transform Cannon;
    [SerializeField]
    Transform FirePoint;
    [SerializeField]
    LaserScript Laser;


    [Header("Bullet")]
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    float BulletSpeed;

    [SerializeField]
    PlayerInputController input;
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    VehicleController vehicleController;

    [SerializeField]
    Vector3 rotation;

    [SerializeField]
    float rotationSpeed;

    public Vector3 Local;
    public Vector3 global;
    //debug


    [SerializeField]
    float diff;
    public float rotNormalized;
    //debug

    void Awake()
    {

        
    }

    void FixedUpdate()
    {
        
        global = Cannon.rotation.eulerAngles;

        if (playerController)
        {
            rotation = playerController.lookDirection.eulerAngles;
        }
        // destined rotation in player viewing direction

        diff = Mathf.DeltaAngle(Turret.rotation.eulerAngles.y, rotation.y);
        // angle difference

        float rotTime = Mathf.Abs(diff) / rotationSpeed;
        // time to rotate

        rotNormalized = Mathf.Clamp01(Time.deltaTime / rotTime);
        Quaternion target = Quaternion.Lerp(Quaternion.Euler(0f,Turret.rotation.eulerAngles.y,0f), Quaternion.Euler( 0f, rotation.y,0f), rotNormalized);
        // current target rotation in linear rotation of turret to designeted angle
        
        Turret.rotation = Quaternion.Euler(target.eulerAngles);

        Turret.localRotation = Quaternion.Euler(0f, Turret.localEulerAngles.y, 0f);
        // setting turret in correct rotation of vehicle
        

        Vector3 CannonViewTarget = Turret.position;
        CannonViewTarget = CannonViewTarget + 2f * Turret.forward;
        CannonViewTarget = new Vector3(CannonViewTarget.x, Cannon.position.y, CannonViewTarget.z);
        // position to which i want cannon to look, but level in height

        Cannon.LookAt(CannonViewTarget);
        Cannon.localEulerAngles = new Vector3(Cannon.localEulerAngles.x, 0f, 0f);
        // setting rotation to look at position, then zeroing in other axis
    }

    public void SetInput(PlayerInputController _input,PlayerController _player)
    {
        input = _input;
        input.fire += Shoot;
        playerController= _player;
    }

    public void SetController(VehicleController controller)
    {
        vehicleController = controller;
    }

    void Shoot()
    {
            Debug.Log("NAPIERDALAC");
            GameObject Shell = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody rb = Shell.GetComponent<Rigidbody>();
            rb.AddForce(Shell.transform.forward * BulletSpeed);
    }

}
