using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingLR : MonoBehaviour
{
    // Variables
    private Vector3 ogPosition; // original position of rock entering boundary field; to be moved

    public int yBoundary1, xBoundary1, yBoundary2, xBoundary2; // Coordinates of Boundary field

    // Start is called before the first frame update
    void Start()
    {
        
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


        // Moving the X values of the colliding object
        
        if (IsPositive(ogPosition.x) == false)
        {
            other.gameObject.transform.position = new Vector3(xBoundary1, ogPosition.y, ogPosition.z);
        }
        else if (IsPositive(ogPosition.x) == true)
        {
            other.gameObject.transform.position = new Vector3(xBoundary2, ogPosition.y, ogPosition.z);
        }
        else
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            Debug.Log(ogPosition);
        }       



    }

    public bool IsPositive(float num)
    {
        if (num >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
