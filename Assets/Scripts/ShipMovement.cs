using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 5.0f;
    public float torque = 1.0f;
    public float boltDistance = 0.5f;
    public bool isHit = false;
    public Sprite falcon;
    public Sprite falcon1;
    public GameObject projectilePrefab;
    public Animator animator;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the ships rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the sprite to the default falcon sprite each frame, unless changed otherwise
        GetComponent<SpriteRenderer>().sprite = falcon;

        // Move the ship forward
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector2(0, force));

            //Swaps the sprite with the thrusters sprite
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

        //Launches bolt from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + transform.up * boltDistance, transform.rotation);
        }
    }
    void OnBecameInvisible()
    {
        //Sets the ships position to the origin if it goes off screen
        rb.position = Vector2.zero;
    }
}
