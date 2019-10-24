using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float boltSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the bolts rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Adds force to the bolt multiplied by the boltSpeed
        rb.AddRelativeForce(Vector2.up * boltSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        //Destroys the bolt when it goes off screen
        Destroy(gameObject);
    }
}
