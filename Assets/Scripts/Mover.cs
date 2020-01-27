using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed = 25f;
    public Rigidbody2D Bullet;
    public float Shotduration = 0.6f;
    
        // Use this for initialization
        void Start()
        {
        // Set the bullet to destroy itself after 1 seconds
        Destroy(gameObject, Shotduration);

        // Push the bullet in the direction it is facing
        GetComponent<Rigidbody2D>()
                .AddForce(transform.up * 400);
        }

    }
