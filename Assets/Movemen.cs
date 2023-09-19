using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movemen : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int lives = 3;
    public Text livesText;

    private Rigidbody rigidBody;
    private bool isJumping = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    public void RestarVida()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void Update()
    {
        //livesText.text = "Vidas: " + lives;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            RestarVida();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
