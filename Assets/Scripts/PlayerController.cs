using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputController input;
    PlayersManager playerManager;

    int playerIndex;

    public float test1;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayersManager.Instance;

        playerManager.AssignPlayer(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // this.transform.Translate( input.GetSteering().x, 0f, input.GetSteering().y);
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
    }
}
