using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Ball ball = collision.GetComponent<Ball>();
            BallManager.Instance.Balls.Remove(ball);
            ball.Die();
        }
    }
}
