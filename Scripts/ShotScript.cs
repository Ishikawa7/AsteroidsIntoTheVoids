using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float shotSpeed = 20;
    Rigidbody shotBody;
    void Start()
    {
        shotBody = GetComponent<Rigidbody>();
        shotBody.velocity = transform.forward * shotSpeed;
    }

}
