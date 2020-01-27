using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float RotateSpeed = 30f;
    public GameObject shot;
    public ParticleSystem particles;
    public Transform shotSpawn;
    public float fireRate;
    public AudioSource MusicClip;
    public AudioSource MusicClip2;


    private float nextFire;
    private Rigidbody2D rb2d;
    private bool pause;
    private bool respawn;
    private gameController gameController;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pause  =  false;
        respawn = false;
        particles.Stop();
        GetComponent<ParticleSystem>();


        GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); //finds the DestroyObject script
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <gameController>();
        }

        if (gameController == null)
        {
            Debug.Log ("Cannot find 'gameController' script");
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (pause == true)
            {
                return;
            }

            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            MusicClip.Play();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pause == true)
            {
                return;
            }

            if (respawn == true)
            {
                return;
            }

            //this controls the engine - Will
            Debug.Log ("Engage!");
            particles.Play();
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (pause == true)
            {
                return;
            }

            
            if (respawn == true)
            {
                return;
            }

            Debug.Log ("Full Stop!");
            particles.Stop();
        }
    }


    void FixedUpdate()
    {
        if (respawn == true)
            {
                return;
            }
        
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0,moveVertical);
        rb2d.AddRelativeForce(movement * speed);

        // Rotate the ship if necessary
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") *
            RotateSpeed * Time.deltaTime); 
    }


    public void stopShot() //to stop players being able to shoot while game is paused - Will
    {
        pause = true;
    }

    public void resumeShot() //tell PlayerController to allow player to resume shooting - Will
    {
        pause = false;
    }

    public void despawn()
    {
        respawn = true;
    }

    public void respawnPlayer()
    {
        respawn = false;
    }


    public void killPlayer() //this will destroy the player after all lives are lost - Will
    {
        Debug.Log ("We blew up!");
        Destroy(gameObject);
    }
}
