using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Windows;
using UnityEditor;
using Unity.VisualScripting;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour
{
    int Index;

    PlayerInputController input;

    [SerializeField]
    VehicleController vehicle;
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Vector2 lookAround;


    [Header("Spawns")]
    [SerializeField]
    Transform instantiatePoint;
    [SerializeField]
    Transform camPoint;
    [SerializeField]
    Transform playerPoint;

    [Header("Camera")]
    [SerializeField]
    Transform camParent;
    [SerializeField]
    Transform camLook;

    [SerializeField]
    public Quaternion lookDirection;

    [SerializeField]
    Vector2 offset;
    [SerializeField]
    Transform target;
    public Vector3 debug;
    [SerializeField]
    float camSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        input= GetComponent<PlayerInputController>();

        if (vehicle)
        {
            vehicle.SetInput(input,this);
        }

        //target = vehicle.transform;
    }

    private void Start()
    {
        GameObject tank = Instantiate(prefab, instantiatePoint.position, instantiatePoint.rotation, this.transform);
        SelfDriveScript selfDrive = tank.AddComponent<SelfDriveScript>();
        selfDrive.SetTargets(camPoint, playerPoint,this);
        vehicle = tank.GetComponent<VehicleController>();
        vehicle.SetDrive(selfDrive);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //debug = target.transform.position;
        //cam.transform.LookAt(target);

        if (target)
        {
            
            lookAround = input.lookAround;

            camParent.position = Vector3.Lerp(camParent.position, target.position, camSpeed * Time.deltaTime);

            //Vector3 toPos = target.transform.position + ;
            //debug = toPos;

            camLook.localPosition = Vector3.Lerp(camLook.localPosition, new Vector3(lookAround.x * offset.x, 0f, lookAround.y * offset.y), camSpeed * Time.deltaTime);

            Vector3 relativePos = camLook.position - camParent.position;
            if (relativePos != Vector3.zero)
            {
                lookDirection = Quaternion.LookRotation(relativePos);
            }
        }
    }

    public void SetCamera()
    {
        target = vehicle.transform;
    }
    
    public void SetPlayerInput()
    {
        vehicle.SetInput(input, this);
    }

    void OnDrawGizmos()
    {
        GUIStyle styl = new GUIStyle
        {
            alignment = TextAnchor.UpperLeft
        };

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(camParent.position, 0.4f);
        Gizmos.color = new Color(1, 0.8f, 0.4f, 1);
        Gizmos.DrawSphere(camLook.position, 0.4f);
        Handles.color = new Color(1, 0.8f, 0.4f, 1);
        Handles.Label(camLook.position, "PlayerViewCenter", styl);
    }
}
