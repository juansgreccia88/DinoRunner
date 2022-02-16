using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        WAITINGTOSTART,
        PLAY,
        WAITINGTORESTART
    }

    public GameState gameState;


    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.WAITINGTOSTART;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (gameState == GameState.WAITINGTOSTART)
            {
                gameState = GameState.PLAY;
            }
        }
    }
}
