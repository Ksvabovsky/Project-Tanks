using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    int players;

    public float spacing = 200f;

    [SerializeField] private GameObject player1character;
    [SerializeField] private GameObject player2character;
    [SerializeField] private GameObject player3character;
    [SerializeField] private GameObject player4character;

    //[SerializeField] private Transform iconParent;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayersManager.OnPlayerJoined += OnPlayerJoined;


        player1character.SetActive(false);
        player2character.SetActive(false);
        player3character.SetActive(false);
        player4character.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Funkcja, która bêdzie wywo³ana po do³¹czeniu gracza
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        AddPlayer(playerInput);
        Debug.Log("O, ktoœ do³¹czy³!");
    }

    void AddPlayer(PlayerInput playerInput)
    {

        switch (playerInput.playerIndex + 1)
        {
            case 1:
                player1character.SetActive(true);
                MenuPlayerController p1 = player1character.GetComponent<MenuPlayerController>();
                PlayerInputController p1Input = playerInput.gameObject.GetComponent<PlayerInputController>();
                
                p1.playerInit(p1Input);
                Debug.Log("inited player 1");
                break;
            case 2:
                player2character.SetActive(true);
                MenuPlayerController p2 = player1character.GetComponent<MenuPlayerController>();
                PlayerInputController p2Input = playerInput.gameObject.GetComponent<PlayerInputController>();
                p2.playerInit(p2Input);
                break;
            case 3:
                player3character.SetActive(true);
                MenuPlayerController p3 = player1character.GetComponent<MenuPlayerController>();
                PlayerInputController p3Input = playerInput.gameObject.GetComponent<PlayerInputController>();
                p3.playerInit(p3Input);
                break;
            case 4:
                player4character.SetActive(true);
                MenuPlayerController p4 = player1character.GetComponent<MenuPlayerController>();
                PlayerInputController p4Input = playerInput.gameObject.GetComponent<PlayerInputController>();
                p4.playerInit(p4Input);
                break;

        }

    }
}
