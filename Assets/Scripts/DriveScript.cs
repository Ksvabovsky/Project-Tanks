using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class DriveScript : MonoBehaviour
{
    [SerializeField]
    InputInterface input;

    Rigidbody rb;

    [SerializeField]
    Transform massCenter;

    [SerializeField]
    Vector2 steeringInput;

    [SerializeField]
    float Power;
    [SerializeField]
    float Turn;
    [SerializeField]
    float brakingForce;

    float Xinput;
    float Yinput;
    [SerializeField]
    bool braking;

    [SerializeField]
    float speed;
    [SerializeField]
    float maxSpeed;


    [SerializeField]
    Axle[] axles;



    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        //rb.centerOfMass = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (input ==null)
        {
            return;
        }
        steeringInput = input.GetSteering();
        //braking = input.brake;

        Yinput = steeringInput.y;
        Xinput = steeringInput.x;

        foreach(Axle axle in axles)
        {
            if (Yinput != 0f && axle.motor == true)
            {
                if (speed < maxSpeed)
                {
                    axle.rightWheel.motorTorque = Power * Yinput;
                    axle.leftWheel.motorTorque = Power * Yinput;
                }
                else
                {
                    axle.rightWheel.motorTorque = 0f;
                    axle.leftWheel.motorTorque = 0f;
                }
                axle.rightWheel.brakeTorque = 0f;
                axle.leftWheel.brakeTorque = 0f;
                braking = false;
            }
            else
            {
                axle.rightWheel.motorTorque = 0;
                axle.leftWheel.motorTorque = 0;
                axle.rightWheel.brakeTorque = brakingForce;
                axle.leftWheel.brakeTorque = brakingForce;
                braking = true;
            }


            if (Xinput != 0f && axle.steering == true)
            {
                axle.rightWheel.steerAngle = Turn * Xinput;
                axle.leftWheel.steerAngle = Turn * Xinput;
            }

            axle.SetMeshesToColliders();
        }

        speed = 2f* 3.14f * axles[0].rightWheel.rpm * axles[0].rightWheel.radius*60/1000;
        speed = Mathf.Round(speed);
    }

    public void SetInput(InputInterface _input)
    {
        input= _input;
    }

    
}

[System.Serializable]
public class Axle
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheelMesh;
    public Transform rightWheelMesh;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?

    public void SetMeshesToColliders()
    {
        MeshToCollider(leftWheel, leftWheelMesh);
        MeshToCollider(rightWheel, rightWheelMesh);
    }

    public void MeshToCollider(WheelCollider collider, Transform wheelMesh)
    {
        if (wheelMesh)
        {
            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            wheelMesh.transform.position = position;
            wheelMesh.transform.rotation = rotation;
        }
    }

}
