using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingAsteroids : MonoBehaviour
{
    // Variables
    private Vector3 ogPosition; // original position of rock entering boundary field; to be moved

    public int yBoundary1, xBoundary1, yBoundary2, xBoundary2; // Coordinates of Boundary field

    // Start is called before the first frame update
    void Start()
    {
        /*
        Debug.Log(yBoundary1);
        Debug.Log(xBoundary1);
        Debug.Log(xBoundary2);
        Debug.Log(yBoundary2);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function for teleporting asteriods when hitting the boundaries
    private void OnTriggerEnter2D(Collider2D other)
    {
        ogPosition = other.transform.position;
        Debug.Log(ogPosition);        

        //Newer, quicker code

        // Moving the Y value of the colliding object
          
        if (IsPositive(ogPosition.y) == false)
        {
            // other.transform.position.y = (yBoundary1 - 1);
            other.gameObject.transform.position = new Vector3(ogPosition.x, yBoundary1, ogPosition.z);
        }
        else if (IsPositive(ogPosition.y) == true)
        {
            other.gameObject.transform.position = new Vector3(ogPosition.x, yBoundary2, ogPosition.z);
        }
        else
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            Debug.Log(ogPosition);
        }       
        

        // Moving the X values of the colliding object
        // -> Moved to teleporting LR
        /*
        if (IsPositive(ogPosition.x) == false)
        {
            other.gameObject.transform.position = new Vector3(xBoundary1 - 2, ogPosition.y, ogPosition.z);
        }
        else if (IsPositive(ogPosition.x) == true)
        {
            other.gameObject.transform.position = new Vector3(xBoundary2 + 2, ogPosition.y, ogPosition.z);
        }
        else
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            Debug.Log(ogPosition);
        }
        */
        
        
        
    }

    public bool IsPositive(float num)
    {
        if(num >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
