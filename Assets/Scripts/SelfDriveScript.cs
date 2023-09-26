using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelfDriveScript : MonoBehaviour, InputInterface
{
    [SerializeField]
    Vector2 steering;

    [SerializeField]
    Transform camPoint;
    [SerializeField]
    Transform playerPoint;

    [SerializeField]
    float distance;
    [SerializeField]
    float direction;

    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 targetPos;

    [SerializeField]
    Vector3 vehiclePos;

    [SerializeField]
    PlayerController controller;


    // Start is called before the first frame update
    void Start()
    {
       // target = point1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            targetPos = new Vector3(target.position.x, 0f, target.position.z) ;
            vehiclePos = new Vector3 (gameObject.transform.position.x, 0f, gameObject.transform.position.z);
            distance = Vector3.Distance(targetPos, vehiclePos);

            Vector3 targetDirection = targetPos - vehiclePos;

            if (distance < 1f && target)
            {
                if (target == camPoint)
                {
                    target = playerPoint;
                    targetPos = new Vector3(target.position.x, 0f, target.position.z);
                    controller.SetCamera();
                }
                else
                {
                    if (target == playerPoint)
                    {
                        controller.SetPlayerInput();
                        target = null;
                    }
                }

            }

            if (distance > 1f)
            {
                
                float angleToTarget = Vector3.SignedAngle(gameObject.transform.forward, targetDirection,Vector3.up);

                angleToTarget = (angleToTarget + 180.0f) % 360.0f - 180.0f;

                // Calculate the normalized rotation based on the angle
                float dir = 0f;
                direction = angleToTarget / 180.0f;
                //if (direction < -0.2f) dir = -1f;
                //else
                //if (direction > 0.2f) dir = 1f;
                //else
                dir = direction;



                steering = new Vector2(dir, 0.1f);
            }
            else
            {
                steering = new Vector2(0f, 0f);
                
            }
        }
    }

    public Vector2 GetSteering()
    {
        return steering;
    }

    public void SetTargets(Transform _camPoint, Transform _playerPoint, PlayerController _controller)
    {
        camPoint = _camPoint;
        playerPoint = _playerPoint;
        target = _camPoint;
        targetPos = new Vector2(target.position.x, target.position.z);
        controller = _controller;
    }

    void OnDrawGizmos()
    {
        GUIStyle styl = new GUIStyle
        {
            alignment = TextAnchor.UpperLeft
        };

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(camPoint.position, 0.4f);
        Gizmos.DrawSphere(playerPoint.position, 0.4f);
        Handles.color = new Color(1, 0.8f, 0.4f, 1);
        Handles.Label(camPoint.position, "camPoint", styl);
        Handles.Label(playerPoint.position, "playerPoint", styl);
    }

}
