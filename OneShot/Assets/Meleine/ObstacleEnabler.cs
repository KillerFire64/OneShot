using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEnable : MonoBehaviour
{
    public GameObject chicken;
    public GameObject cactus;
    public GameObject weed;

    public float obstacleInSceneTimer;
    public float maxObjectInSceneTimer;

    public float spawnTimer;
    public float maxSpawnTimer;
    public float minSpawnTimer;
    public int whichObstacle;

    public bool objectInScene;

    private void Start()
    {
        spawnTimer = minSpawnTimer;
        obstacleInSceneTimer = maxObjectInSceneTimer;

        weed.SetActive(false);
        chicken.SetActive(false);
        cactus.SetActive(false);

        objectInScene = false;
    }

    private void Update()
    {
        if(objectInScene)
        {
            obstacleInSceneTimer -= Time.deltaTime;

            if(obstacleInSceneTimer <= 0)
            {
                whichObstacle = 0;
                weed.SetActive(false);
                chicken.SetActive(false);
                cactus.SetActive(false);
                obstacleInSceneTimer = maxObjectInSceneTimer;
                objectInScene = false;
            }
        }

        spawnTimer -= Time.deltaTime;

        if(objectInScene == false)
        {
            if (spawnTimer <= 0)
            {
                whichObstacle = Random.Range(1, 4);
                SpawnObstacle();
            }

            if (whichObstacle == 1)
            {
                chicken.SetActive(true);
                objectInScene = true;
            }
            if (whichObstacle == 2)
            {
                cactus.SetActive(true);
                objectInScene = true;
            }
            if (whichObstacle == 3)
            {
                weed?.SetActive(true);
                objectInScene = true;
            }
        }
    }

    public void SpawnObstacle()
    {
        spawnTimer = Random.RandomRange(minSpawnTimer, maxSpawnTimer);
        Mathf.FloorToInt(spawnTimer);
    }
}
