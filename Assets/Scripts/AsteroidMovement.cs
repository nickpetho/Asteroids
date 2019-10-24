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
        //Gets the asteroids rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Sets the torque to a random number between -5 and 5
        torque = Random.Range(minTorque, maxTorque);

        //Sets the force to a random number between 1 and 2
        force = Random.Range(minForce, maxForce);

        //Adds the torque and force to the asteroid
        rb.AddTorque(torque);
        rb.AddRelativeForce(new Vector2(0, force), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        //Destroys the asteroid when it goes off screen
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Checks to see if the asteroid collided with a blaster shot
        GameObject g = col.gameObject;
        if (g.CompareTag("Blaster"))
        {
            //Destroys the blaster object
            GameObject.Destroy(g);

            // Instantiates an explosion prefab in the place of the asteroid
            GameObject exp = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Makes sure explosion destroyed in 2 seconds
            GameObject.Destroy(exp, 2);

            // Destroys the gameObject component of this object
            Destroy(this.gameObject);
        }

        else if (g.CompareTag("Player"))
        {
            //Destroys the player object
            GameObject.Destroy(g);

            // Instantiates an explosion prefab in the place of the player
            GameObject exp = (GameObject)Instantiate(explosionPrefab, g.transform.position, Quaternion.identity);

            // Makes sure explosion destroyed in 2 seconds
            GameObject.Destroy(exp, 2);
        }
    }
}
