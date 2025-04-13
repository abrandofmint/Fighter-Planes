using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public GameObject healthPrefab;
    public GameObject powerUpPrefab;
    public GameObject shieldPrefab;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject audioPlayer;

    public AudioClip powerupSound;
    public AudioClip powerdownSound;
    public AudioClip healthSound;
    public AudioClip coinSound;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerUpText;
    public TextMeshProUGUI shieldsText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    private bool gameOver;
    public int cloudMove;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        gameOver = false;
        cloudMove = 1;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        AddScore(0);
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateCoin", 5, 5);
        InvokeRepeating("CreateHealthPowerup", 15, 10);
        StartCoroutine(SpawnPowerup());
        powerUpText.text = "";
        //InvokeRepeating("CreateShieldPowerup", 20, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.65f, Random.Range(-verticalScreenSize, verticalScreenSize) * 0.65f, 0), Quaternion.identity);
    }

    void CreateHealthPowerup()
    {
        Instantiate(healthPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.65f, Random.Range(-verticalScreenSize, verticalScreenSize) * 0.65f, 0), Quaternion.identity);
    }

    void CreatePowerup()
    {
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.65f, Random.Range(-verticalScreenSize, verticalScreenSize) * 0.65f, 0), Quaternion.identity);
    }

    public void ManagePowerupText(int powerupType)
    {
        switch (powerupType)
        {
            case 1:
                powerUpText.text = "Speed!";
                break;
            case 2:
                powerUpText.text = "Double Weapon!";
                break;
            case 3:
                powerUpText.text = "Triple Weapon!";
                break;
            default:
                powerUpText.text = "";
                break;
        }

    }

    IEnumerator SpawnPowerup()
    {
        float spawnTime = Random.Range(6, 8);
        yield return new WaitForSeconds(spawnTime);
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }
    /*
    void CreateShieldPowerup()
    {
        Instantiate(shieldPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.65f, Random.Range(-verticalScreenSize, verticalScreenSize) * 0.65f, 0), Quaternion.identity);
    }
    */
    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerupSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerdownSound);
                break;
            case 3:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(healthSound);
                break;
            case 4:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(coinSound);
                break;
        }
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
        cloudMove = 0;
    }


    public void ChangeShieldsText(bool active)
    {
        if (active)
        {
            shieldsText.text = "Shield Active!";
        }
        else
        {
            shieldsText.text = "";
        }
        
    }
}
