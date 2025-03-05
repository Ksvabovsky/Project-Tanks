using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoinLeftHandler : MonoBehaviour
{
    // Definiowanie delegatów
    public delegate void PlayerJoinedAction(PlayerInput playerInput);
    public delegate void PlayerLeftAction(PlayerInput playerInput);

    // Deklarowanie eventów
    public static event PlayerJoinedAction OnPlayerJoined;
    public static event PlayerLeftAction OnPlayerLeft;

    // Metoda obs³uguj¹ca do³¹czenie gracza
    public void HandlePlayerJoined(PlayerInput playerInput)
    {
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
}
