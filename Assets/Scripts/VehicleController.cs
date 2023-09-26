using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VehicleController : MonoBehaviour
{

    [SerializeField]
    GameObject Vehicle;
    [SerializeField]
    DriveScript drive;
    [SerializeField]
    TurretScript turret;

    PlayerInputController input;
    PlayerController playerController;

    


    // Start is called before the first frame update
    void Start()
    {
        
        
        //input = GetComponent<PlayerInputController>();

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


    }

    public void SetInput(PlayerInputController _input,PlayerController _player)
    {
        input = _input;
        playerController = _player;

        drive = Vehicle.GetComponent<DriveScript>();
        drive.SetInput(input);

        turret = Vehicle.GetComponent<TurretScript>();
        turret.SetInput(input,playerController);
        turret.SetController(this);
    }

    public void SetDrive(InputInterface _input)
    {
        drive.SetInput(_input);
    }


}
