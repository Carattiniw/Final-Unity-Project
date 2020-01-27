using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText; //Edit by Ashley for lives text. -Ash
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI winText;
    public bool isDead;
    public bool hardMode;
    public int playerHealth;

    private int score;
    //private int playerHealth; //player health -Ash
    private DestroyObject DestroyObject; //hopefully will help call on the DestroyObject script
    private PlayerController PlayerController;//call the PlayerController script


    // Testing for asteroid spawning
    public GameObject asteroid1;
    public int asteroidsPerWave = 3;
    private int wave=1;
    private int asteroidCount;
    private int extraLife;

    // Reference to player for movement
    public GameObject player;
    Rigidbody2D playerRB;
    public int pIFrames = 6;
    

    // Start is called before the first frame update
    void Start()
    {
        //Application.LoadLevel("MainMenu");
        score = 0;
        extraLife = 0;
        //playerHealth = 3;
        isDead = false;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + playerHealth;
        gameoverText.text = "";
        restartText.text = "";
        winText.text = "";

        // Spawning asteroids
        SpawnAsteroids();
        

        GameObject PlayerControllerObject = GameObject.FindWithTag ("Player"); //finds the DestroyObject script
        if (PlayerControllerObject != null)
        {
            PlayerController = PlayerControllerObject.GetComponent <PlayerController>();
        }

        if (PlayerController == null)
        {
            Debug.Log ("Cannot find 'PlayerController' script");
        }
    }

    // Asteroid Spawning Function - Matthew 1/20/20
     
    void SpawnAsteroids()
    {
 
        EndCurrentWave();
 
        // Decide how many asteroids to spawn
        // If any asteroids left over from previous game, subtract them
        asteroidCount = (wave * asteroidsPerWave);
 
        for (int i = 0; i < asteroidCount; i++) {
 
            // Spawn an asteroid
            Instantiate(asteroid1,
                new Vector3(Random.Range(-9.0f, 9.0f),
                    Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0,0,Random.Range(-0.0f, 359.0f)));
 
        }
    }

    public void DecrementAsteroids()
    {
        asteroidCount--;
    }

    public void AsteroidSplit()
    {
        // Called whenever a large asteroid gets broken apart
        asteroidCount+=1;
    }

    void EndCurrentWave()
    {
        GameObject[] asteroids =
            GameObject.FindGameObjectsWithTag("Large Asteroid");
 
        foreach (GameObject current in asteroids) {
            GameObject.Destroy (current);
        }
 
        GameObject[] asteroids2 =
            GameObject.FindGameObjectsWithTag("Small Asteroid");
 
        foreach (GameObject current in asteroids2) {
            GameObject.Destroy (current);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            if (Input.GetKeyDown(KeyCode.R)) //will reload the current level ONLY on gameover - Will
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddScore(int newpointValue)
    {
        score += newpointValue;
        UpdateScore(); //receives signal from DestroyObject script and passes it to UpdateScore
        Debug.Log(asteroidCount);
        // Additions for ending wave of asteroids
        if(asteroidCount < 1)
        {
            wave++;
            SpawnAsteroids();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;

        if (hardMode == true)
        {
            return;//if the hardMode button is check on the inspector, players cannot earn lives - Will
        }
        
        if (score >= 2000 * extraLife) //earn an extra life every 2k points - Will
        {
            playerHealth++;
            extraLife++;
            livesText.text = "Lives: " + playerHealth;
        }


        if (score >= 10000) //enables a "win" scenario - Will
        {
            isDead = true;
            PlayerController.stopShot();
            winText.text = "You Win!";
            gameoverText.text = "Game Over";
            restartText.text = "Press R to restart";
            PlayerController.particles.Stop();
            PlayerController.despawn();
            player.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            player.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }


    public void SubLive() // code of player health and lives-Ash
    {
        Debug.Log ("The sublive function works!"); //to see if script works - Will

        playerHealth--;
        livesText.text = "Lives: " + playerHealth;
        player.gameObject.GetComponent<Renderer>().enabled = false;
        player.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(playerRespawn());
        //UpdateLives();       




        if (playerHealth <= 0)
        {
            playerHealth = 0; //keeps the count from going negative
            isDead = true;
            Debug.Log ("We're dead!");//checks to see if statement is working
            gameoverText.text = "Game Over";
            restartText.text = "Press R to restart";
            

            //DestroyObject.killPlayer(); //supposed to destroy player in DestroyObject - Will
            PlayerController.killPlayer();
        }
    }

    IEnumerator playerRespawn()
    {
        PlayerController.particles.Stop();
        PlayerController.despawn();//stop players from being able to move - Will
        PlayerController.stopShot(); //prevents players from being able to shoot while invisible - Will
        player.transform.position = new Vector2(0, 0);
        playerRB = player.GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2);

        player.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.gameObject.GetComponent<Renderer>().enabled = true;

        for (int i = 0; i < pIFrames; i++)
        {
            player.gameObject.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.10f);
            Debug.Log("We made it");
            player.gameObject.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.10f);
            PlayerController.resumeShot();
            PlayerController.respawnPlayer();//give control back to players - Will
        }

        player.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        PlayerController.resumeShot();

    }
    


    void UpdateLives() // code of player health and lives-Ash
    //not being used ATM - Will
    {
        livesText.text = "Lives: " + playerHealth;
    }
}
    


