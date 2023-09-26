using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
     
    public static PlayersManager Instance { get; private set; }

    [SerializeField]
    Players players;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != this && Instance) {
        
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Players GetPlayers()
    {
        return players;
    }

    public PlayerController GetPlayer(int index)
    {
        PlayerController tmp = null;

        switch(index)
        {
            case 1:
                tmp = players._player1;
                break;
            case 2:
                tmp = players._player2;
                break;
            case 3:
                tmp = players._player3;
                break;
            case 4:
                tmp = players._player4;
                break;
        }
        return tmp;
    }

    public struct Players
    {
        public PlayerController _player1;
        public PlayerController _player2;
        public PlayerController _player3;
        public PlayerController _player4;
    }
}
