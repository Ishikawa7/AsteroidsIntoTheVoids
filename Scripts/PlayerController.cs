using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
[System.Serializable]
public class Tilt
{
    public float xTilt, yTilt, zTilt;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    float horizontal, vertical;
    Vector3 movement;
    Rigidbody playerBody;
    public Boundary boundary;
    public Tilt tilt;
    private float yRotation = 0.0f;

    public Transform shotPoint;
    public GameObject shot;
    public float fireDelta = 0.5F;
    private GameObject newShot;
    private float myTime = 0.0F;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > fireDelta)
        {
            newShot = Instantiate(
                shot,
                new Vector3(shotPoint.position.x, 0.0f, shotPoint.position.z),
                Quaternion.Euler(shotPoint.rotation.x, 0.0f, shotPoint.position.z)
                ) as GameObject;
            myTime = 0.0F;
        }
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0.0f, vertical);
        playerBody.velocity = movement * speed;
        
        playerBody.position= new Vector3
        (
            Mathf.Clamp(playerBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(playerBody.position.z, boundary.zMin, boundary.zMax)
        );
        if (playerBody.velocity.z > 0)
        {
            yRotation = playerBody.velocity.x* playerBody.velocity.z * tilt.yTilt ;
        }
        else{
            yRotation = 0.0f;
        }
        playerBody.rotation = Quaternion.Euler(
            playerBody.velocity.z * -tilt.xTilt,
            yRotation,
            playerBody.velocity.x * -tilt.zTilt);
    }
}
