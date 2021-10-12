using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    public float moveSpeed;
    public CoinSpawn coinSpawn;
    private Rigidbody2D Rigidbody2D;
    public ScoreController scoreController;

    private void Start()
    {
       
        ResetBall();

       
    }
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(xInput, yInput).normalized;

        Rigidbody2D.velocity = direction * moveSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            scoreController.IncreaseCurrentScore(1);
            Destroy(collision.gameObject);
            StartCoroutine(delaySpawn());
        }
    }
    private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            float posX = Random.Range(-coinSpawn.boxTemplateWidth / 2, coinSpawn.boxTemplateWidth / 2);
            float posY = Random.Range(-coinSpawn.boxTemplateHeight / 2, coinSpawn.boxTemplateHeight / 2);
            if (posX != transform.position.x && posY != transform.position.y)
            {
                coinSpawn.SpawnBox(posX, posY);
                break;
            }
        }
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        Rigidbody2D.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        Rigidbody2D.AddForce(new Vector2(10f, 8f));
    }
}
