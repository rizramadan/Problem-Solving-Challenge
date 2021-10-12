using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public Rigidbody2D obstacleTemplate;
    public float boxTemplateHeight = 7f;
    public float boxTemplateWidth = 15f;

    public BallControll ball;

    private List<GameObject> spawnedBox;

    private float delay = 5f;

    private void Start()
    {
        spawnedBox = new List<GameObject>(0);

        while (true)
        {
            float posX = Random.Range(-boxTemplateWidth / 2, boxTemplateWidth / 2);
            float posY = Random.Range(-boxTemplateHeight / 2, boxTemplateHeight / 2);
            if (posX != 0 && posY != 0)
            {
                SpawnObstacle(posX, posY);
                break;
            }
        }
    }
    //time spawn
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0f)
        {
            delay = 5f;
            while (true)
            {
                float posX = Random.Range(-boxTemplateWidth / 2, boxTemplateWidth / 2);
                float posY = Random.Range(-boxTemplateHeight / 2, boxTemplateHeight / 2);
                if (posX != ball.transform.position.x && posY != ball.transform.position.y)
                {
                    SpawnObstacle(posX, posY);
                    break;
                }
            }
        }
    }

    public void SpawnObstacle(float posX, float posY)
    {
        GameObject newBox = Instantiate(obstacleTemplate.gameObject, transform);
        newBox.transform.position = new Vector2(posX, posY);
        spawnedBox.Add(newBox);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, boxTemplateHeight / 2, 0), transform.position + new Vector3(boxTemplateWidth / 2, -boxTemplateHeight / 2, 0), Color.green);
        Debug.DrawLine(transform.position + new Vector3(-boxTemplateWidth / 2, boxTemplateHeight / 2, 0), transform.position + new Vector3(-boxTemplateWidth / 2, -boxTemplateHeight / 2, 0), Color.green);
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, boxTemplateHeight / 2), transform.position + new Vector3(-boxTemplateWidth / 2, boxTemplateHeight / 2), Color.green);
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, -boxTemplateHeight / 2), transform.position + new Vector3(-boxTemplateWidth / 2, -boxTemplateHeight / 2), Color.green);
    }
}
