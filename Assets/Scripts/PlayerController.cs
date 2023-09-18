using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    GameObject Vehicle;
    [SerializeField]
    DriveScript drive;
    [SerializeField]
    TurretScript turret;

    PlayerInputController input;

    Vector2 lookAround;

    [SerializeField]
    Transform camParent;
    [SerializeField]
    Transform camLook;

    [SerializeField]
    public Quaternion lookTransform;

    [SerializeField]
    Vector2 offset;
    [SerializeField]
    Transform target;
    public Vector3 debug;
    [SerializeField]
    float camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = Vehicle.transform;
        
        input = GetComponent<PlayerInputController>();

        drive = Vehicle.GetComponent<DriveScript>();
        drive.SetInput(input);

        turret= Vehicle.GetComponent<TurretScript>();
        turret.SetInput(input);
        turret.SetController(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //debug = target.transform.position;
        //cam.transform.LookAt(target);

        lookAround = input.lookAround;

        camParent.position = Vector3.Lerp(camParent.position, target.position, camSpeed * Time.deltaTime);

        //Vector3 toPos = target.transform.position + ;
        //debug = toPos;

        camLook.localPosition = Vector3.Lerp(camLook.localPosition, new Vector3(lookAround.x * offset.x, 0f, lookAround.y * offset.y), camSpeed * Time.deltaTime);

        Vector3 relativePos = camLook.position - camParent.position;
        if (relativePos != Vector3.zero)
        {
            lookTransform = Quaternion.LookRotation(relativePos);
        }


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
