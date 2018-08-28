using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject fireball;
    public float jumpSpeed = 6;
    public GameObject footPoint;
    public float footRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    int direction = 1;
    float startScaleX;

    Animator animator;

	void Start ()
	{
        Debug.Log("Федя");
        startScaleX = transform.localScale.x;
        animator = GetComponent<Animator>();
    }
	
	void Update ()
	{
        isGrounded = Physics2D.OverlapCircle(footPoint.transform.position, footRadius, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        }
        // Debug.Log("лохи вы все");
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (moveX < 0)
        {
            direction = -1;
        }
        if (moveX > 0)
        {
            direction = 1;
        }

        if (moveX == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(fireball, transform.position, transform.rotation);
            ball.GetComponent<FireballController>().direction = direction;
        }


        transform.localScale = new Vector3(direction * startScaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(moveX, 0, 0);
        
	}
}
