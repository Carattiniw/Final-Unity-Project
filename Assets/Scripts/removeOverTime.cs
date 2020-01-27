using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeOverTime : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, lifetime); //removes explosions after x amount of time - Will
    }
}
