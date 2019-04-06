using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Behavior : MonoBehaviour
{
    public float level = 1;
    private Rigidbody asteroidBody;
    public float tumble = 1;
    void Start()
    {
        asteroidBody = GetComponent<Rigidbody>();
        asteroidBody.velocity = new Vector3(0, 0, -Random.value * level * 10);
        asteroidBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
    
}
