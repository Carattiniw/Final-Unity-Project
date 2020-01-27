using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int pointValue; //how many points player earns
    public GameObject smallAsteroid; // Link to small asteroid to spawn
    public GameObject explosion;
    public GameObject playerExplosion;
    //public CameraShake cameraShake;

    private gameController gameController;
    private CameraShake cameraShake;



    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <gameController>();
        }

        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }


        GameObject cameraShakeObject = GameObject.FindWithTag ("MainCamera");
        if (cameraShakeObject != null)
        {
            cameraShake = cameraShakeObject.GetComponent <CameraShake>();
        }

        if (cameraShake == null)
        {
            Debug.Log ("Cannot find 'cameraShake' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Enemy"))
        {
            return;
        }
        // In the case of a large asteroid being destroyed, it wil spawn smaller versions
        if (tag.Equals ("Large Asteroid"))
        {
            StartCoroutine(cameraShake.Shake(.10f, .15f));
            // Spawn small asteroids
            Instantiate (smallAsteroid,
                new Vector3 (transform.position.x - .5f,
                    transform.position.y - .5f, 0),
                    Quaternion.Euler (0, 0, 90));
 
            // Spawn small asteroids
            Instantiate (smallAsteroid,
                new Vector3 (transform.position.x + .5f,
                    transform.position.y - .5f, 0),
                    Quaternion.Euler (0, 0, 270));
 
                gameController.AsteroidSplit (); // +2
 
        }
        if (tag.Equals ("Small Asteroid"))
        {
            StartCoroutine(cameraShake.Shake(.5f, .10f));
            gameController.DecrementAsteroids();
        }


        if (other.CompareTag ("Boundary"))
        {
            return; //will ignore the walls and not remove them.
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }


        if (other.tag == "Player")
        {
            Debug.Log ("That hurts!");
            StartCoroutine(cameraShake.Shake(.15f, .5f));
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.SubLive(); //if player ship collides asteroid or enemy ship reduces 1 health -Ash
            Destroy(gameObject);
            return;
        }


        if (other.tag == "Bullet")
        {
            Debug.Log ("Bullets work!!");
        }

        gameController.AddScore (pointValue);
        Object.Destroy(other.gameObject);
        Destroy(gameObject); //destroy whatever object this script is attached to.
    }
}
