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
