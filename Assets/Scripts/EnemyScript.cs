using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 10;
    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed = 5;
    public int direction = 1;

    public bool movingRight;

	
	void Update ()
	{
        transform.Translate(moveSpeed * direction * Time.deltaTime, 0, 0);
        if (transform.position.x > rightPoint.position.x && movingRight)
        {
            movingRight = false;
        }
        if (transform.position.x < leftPoint.position.x && !movingRight)
        {
            movingRight = true;
        }

        direction = movingRight ? 1 : -1;
    }

    public void ChangeHealth(int health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
