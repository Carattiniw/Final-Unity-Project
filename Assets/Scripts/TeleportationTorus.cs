using UnityEngine;
using System.Collections;
 
public class TeleportationTorus : MonoBehaviour {
 
    // Update is called once per frame
    void Update () {
 
        // Teleport the game object
        if(transform.position.x > 9){
 
            transform.position = new Vector3(-9, transform.position.y, 0);
 
        }
        else if(transform.position.x < -9){
            transform.position = new Vector3(9, transform.position.y, 0);
        }
 
        else if(transform.position.y > 5.45){
            transform.position = new Vector3(transform.position.x, -5.45f, 0);
        }
 
        else if(transform.position.y < -5.45){
            transform.position = new Vector3(transform.position.x, 5.45f, 0);
        }
    }
}