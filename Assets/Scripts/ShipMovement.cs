using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float force = 5.0f;
    public float torque = 1.0f;
    public float boltDistance = 0.5f;
    public bool isHit = false;
    public Sprite falcon;
    public Sprite falcon1;
    Rigidbody2D rb;
    public GameObject projectilePrefab;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = falcon;
        animator.SetBool("isHit", isHit);

        if (!isHit)
        {
            // Move up
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddRelativeForce(new Vector2(0, force));
                GetComponent<SpriteRenderer>().sprite = falcon1;
            }
            // If the left arrow is pressed apply positive torque (clockwise)
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddTorque(torque);
            }
            // If the right arrow is pressed apply negative force (conterclockwise)
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddTorque(-torque);
            }

            //Launch projectile from player
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position + transform.up * boltDistance, transform.rotation);
            }
        }
    }
    void OnBecameInvisible()
    {
        rb.position = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject g = col.gameObject;
        if (g.CompareTag("Enemy"))
        {
            isHit = true;
        }
    }
}
