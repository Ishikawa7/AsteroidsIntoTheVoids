using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_General : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameControllerScript gameController;

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerScript>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(tag == other.tag)
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOverFunction();
        }
        if (other.tag == "Shot")
        {
            gameController.scoreUpdate(scoreValue);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
