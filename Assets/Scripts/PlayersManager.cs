using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PlayersManager : MonoBehaviour
{
     
    public static PlayersManager Instance { get; private set; }

    [SerializeField]
    Players players;


    public int playersCount = 0;

    // Definiowanie delegatów
    public delegate void PlayerJoinedAction(PlayerInput playerInput);
    public delegate void PlayerLeftAction(PlayerInput playerInput);

    // Deklarowanie eventów
    public static event PlayerJoinedAction OnPlayerJoined;
    public static event PlayerLeftAction OnPlayerLeft;

    // Metoda obs³uguj¹ca do³¹czenie gracza
    public void HandlePlayerJoined(PlayerInput playerInput)
    {
        AssignPlayer(playerInput);
        // Broadcast do wszystkich subskrybentów
        OnPlayerJoined?.Invoke(playerInput);
        Debug.Log("Nowy gracz do³¹czy³: " + playerInput.playerIndex);
    }

    // Metoda obs³uguj¹ca opuszczenie gracza
    public void HandlePlayerLeft(PlayerInput playerInput)
    {
        // Broadcast do wszystkich subskrybentów
        OnPlayerLeft?.Invoke(playerInput);
        Debug.Log("Gracz opuœci³ grê: " + playerInput.playerIndex);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != this && Instance) {

            Debug.Log("Im not needed, se ya");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Im the lord now");
            Instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerInputController GetPlayerInput(int index)
    {
        switch (index)
        {
            case 1:
                return players._player1.gameObject.GetComponent<PlayerInputController>();
            case 2:
                return players._player2.GetComponent<PlayerInputController>();
            case 3:
                return players._player3.GetComponent<PlayerInputController>();
            case 4:
                return players._player4.GetComponent<PlayerInputController>();

        }

        return null;
    }

    public Players GetPlayers()
    {
        return players;
    }

    public int GetPlayersCount()
    {
        return playersCount;
    }

    public void AssignPlayer(PlayerInput playerInput)
    {
        PlayerController player_ = playerInput.gameObject.GetComponent<PlayerController>();

        switch (playersCount)
        {
            case 0:
                players._player1 = player_;
                player_.gameObject.name = "Player_1";
                playersCount++;
                player_.SetPlayerIndex(playersCount);
                break;
            case 1:
                players._player2 = player_;
                player_.gameObject.name = "Player_2";
                playersCount++;
                player_.SetPlayerIndex(playersCount);
                break;
            case 2:
                players._player3 = player_;
                player_.gameObject.name = "Player_3";
                playersCount++;
                player_.SetPlayerIndex(playersCount);
                break;
            case 3:
                players._player4 = player_;
                player_.gameObject.name = "Player_4";
                playersCount++;
                player_.SetPlayerIndex(playersCount);
                break;
        }

        Debug.Log("AssignedPlayer"+ playersCount);
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
