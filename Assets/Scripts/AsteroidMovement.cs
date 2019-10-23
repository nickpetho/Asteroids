using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float torque;
    public float minTorque = -5.0f;
    public float maxTorque = 5.0f;
    private float force;
    public float minForce = 1.0f;
    public float maxForce = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torque = Random.Range(minTorque, maxTorque);
        force = Random.Range(minForce, maxForce);
        rb.AddTorque(torque);
        rb.AddRelativeForce(new Vector2(0, force), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
