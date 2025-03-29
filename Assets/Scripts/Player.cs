using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizonatalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = -3.5f;

    public GameObject bulletPrefab;

    // Called at the start of the game
    void Start()
    {
        playerSpeed = 6.0f;
    }

    // Update is called once per frame (60 fps)
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        // Read the input from the player
        horizonatalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Save the Y position of the player before moving
        float oldYPos = transform.position.y;
        // Move the Player
        transform.Translate(new Vector3(horizonatalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        // Player leaves the screen horizontally
        if (transform.position.x >= horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        // Player reaches the middle of the screen or the bottom of the screen vertically
        if (transform.position.y >= 0 || transform.position.y <= verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, oldYPos, 0);
        }
    }

    void Shooting()
    {
        // If the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
