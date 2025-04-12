using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives;
    public int shields;
    private float speed;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        shields = 0;
        speed = 5.0f;
        gameManager.ChangeLivesText(lives);
        gameManager.ChangeShieldsText(shields);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void LoseShields()
    {
        //shields = shields - 1;
        //shields -= 1;
        shields--;
        gameManager.ChangeShieldsText(lives);
    }

    public void PickupCoin()
    {
        gameManager.AddScore(1);
    }

    public void GainALife()
    {
        if (lives < 3)
        {
            lives++;
            gameManager.ChangeLivesText(lives);
        }
    }

    public void GainShields()
    {
        if (shields == 0)
        {
            shields++;
            gameManager.ChangeShieldsText(shields);
        }
    }


    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        if (transform.position.x <= -horizontalScreenSize || transform.position.x > horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y <= -verticalScreenSize || transform.position.y > verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }

    }
}
