using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject [] toSpawn;
    public Vector3 spawnValues;

    public float spawnWait;
    public float startWait;
    public float hazardCount;
    public float waweWait;

    public Text scoreText;
    private int score = 0;
    public Text gameOverText;
    public Text restartText;
    private bool gameOver;
    private bool gameRestart;
    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        gameRestart = false;
        scoreUpdate(0);
        StartCoroutine( SpawnWaves() );
    }
    private void Update()
    {
        if (gameRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main",LoadSceneMode.Single);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject asteroid = toSpawn[Random.Range(0, toSpawn.Length)];
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waweWait);

            if (gameOver)
            {
                restartText.text = "Pres 'R' for restarting the game";
                gameRestart = true;
                break;
            }
        }    
    }

    public void scoreUpdate(int increment)
    {
        score = score + increment;
        scoreText.text = "Score: " + score;
    }
    public void gameOverFunction()
    {
        gameOver = true;
        gameOverText.text = "Game over";
    }
}
