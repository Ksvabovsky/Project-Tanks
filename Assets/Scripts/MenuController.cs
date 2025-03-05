using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    int players;

    public float spacing = 200f;

    [SerializeField] private List<GameObject> playersIcons;

    [SerializeField] private GameObject iconPrefab;

    [SerializeField] private Transform iconParent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerJoinLeftHandler.OnPlayerJoined += OnPlayerJoined;

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Funkcja, która bêdzie wywo³ana po do³¹czeniu gracza
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        AddPlayer();
        Debug.Log("O, ktoœ do³¹czy³!");
    }

    void AddPlayer()
    {
        players = PlayersManager.Instance.GetPlayersCount();
        GameObject newicon = Instantiate(iconPrefab,iconParent);
        IconScript icon = newicon.GetComponent<IconScript>();

        switch (players + 1)
        {
            case 1:
                icon.SetIcon(Color.red, "Gracz 1");
                break;
            case 2:
                icon.SetIcon(Color.blue, "Gracz 2");
                break;
            case 3:
                icon.SetIcon(Color.green, "Gracz 3");
                break;
            case 4:
                icon.SetIcon(Color.yellow, "Gracz 4");
                break;

        }

        newicon.transform.localPosition = new Vector3((spacing * (players) / 2), 0f,0f);
        newicon.transform.localScale = Vector3.zero;
        newicon.transform.DOScale(Vector3.one, 1f);

        int index = 0;
        foreach(GameObject p in playersIcons)
        {
            float tmpPos = -(spacing * (players) / 2)  + (spacing * index );
            Debug.Log(tmpPos);

            p.transform.DOLocalMoveX(tmpPos, 1f, false);
            index++;
        }

        playersIcons.Add(newicon);

    }
}
