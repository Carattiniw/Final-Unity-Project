using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    //
    private Rigidbody2D rb2d; 
    private Vector2 movement;
    public int minSpeed, maxSpeed;
    public int speedMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(Random.Range(-minSpeed, maxSpeed), Random.Range(-minSpeed, maxSpeed));
        rb2d.AddForce(movement * speedMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
