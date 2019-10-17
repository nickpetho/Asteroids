using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float torque;
    public float minTorque = -5.0f;
    public float maxTorque = 5.0f;
    public float force;
    public float minForce = 1.0f;
    public float maxForce = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torque = Random.Range(minTorque, maxTorque);
        force = Random.Range(minForce, maxForce);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector2(0, torque));
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
