using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle prefabObstacle;
    public List<Obstacle> obstacles = new List<Obstacle>();
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private float spawnTime;
    private int nextObstacle = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(13, -1.1f, 0);
        for (int i = 0; i < 10; i++)
        {
            Obstacle newObj = Instantiate(prefabObstacle, spawnPos, Quaternion.identity);
            obstacles.Add(newObj);
            obstacles[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.PLAY)
        {
            if (spawnTime >= 0)
            {
                spawnTime -= Time.deltaTime;
            }
            else
            {
                spawnTime = Random.Range(2f, 4f);
                SpawnObstacle();
            }
            ResetObstacle();
        }

    }

    public void SpawnObstacle()
    {
        obstacles[nextObstacle].gameObject.SetActive(true);
        nextObstacle = (nextObstacle < obstacles.Count - 1) ? nextObstacle + 1 : 0;
    }

    public void ResetObstacle()
    {
        foreach(Obstacle obstacle in obstacles)
        {
            if (obstacle.transform.position.x <= -17)
            {
                obstacle.transform.position = spawnPos;
                obstacle.gameObject.SetActive(false);
            }
        }
    }
}
