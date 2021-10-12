using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll_Prob7 : MonoBehaviour
{
    public float moveSpeed;
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
