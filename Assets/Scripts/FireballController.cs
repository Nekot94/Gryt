using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed = 20;
    public int direction = -1;
    float startScaleX;

	void Start ()
	{
        startScaleX = transform.localScale.x;
    }

    void Update ()
	{
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
        transform.localScale = new Vector3(direction * startScaleX,
            transform.localScale.y, transform.localScale.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
 
            collision.gameObject
                .GetComponent<EnemyScript>().ChangeHealth(1);
        }
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
