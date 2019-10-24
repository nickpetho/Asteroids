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
    public GameObject explosionPrefab;

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

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject g = col.gameObject;
        if (g.CompareTag("Blaster"))
        {
            GameObject.Destroy(g);

            // Instantiate an explosion prefab in its place
            GameObject exp = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Make sure explosion destroyed quickly
            GameObject.Destroy(exp, 2);

            // Destroy self as well by destroying gameObject component of this object
            Destroy(this.gameObject);
        }
    }
}
