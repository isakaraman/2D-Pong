using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallCode : MonoBehaviour
{
    public Rigidbody2D rgdbdy;
    public float speed;
    public float xSpeed, ySpeed;
    public Text playerOneText, playerTwoText;
    int player1,player2;
    public GameObject playerOne, playerTwo;
    Vector2 FirstPosBall, FirstPosPlayerOne, FirstPosPlayerTwo;
    void Start()
    {
       FirstPosBall = new Vector2(transform.position.x,transform.position.y);
       FirstPosPlayerOne = new Vector2(playerOne.transform.position.x, playerOne.transform.position.y);
       FirstPosPlayerTwo = new Vector2(playerTwo.transform.position.x, playerTwo.transform.position.y);
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="PlayerOne")
        {
            rgdbdy.velocity = new Vector2(-xSpeed,Random.Range(-3f,3f));
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            rgdbdy.velocity = new Vector2(xSpeed, Random.Range(-3f, 3f));
        }
        if (collision.gameObject.tag == "upWall")
        {
            rgdbdy.velocity = new Vector2(rgdbdy.velocity.x,-ySpeed);
        }
        if (collision.gameObject.tag == "downWall")
        {
            rgdbdy.velocity = new Vector2(rgdbdy.velocity.x, ySpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="leftWall")
        {

            player2++;
            playerOne.transform.position = new Vector2(FirstPosPlayerOne.x, FirstPosPlayerOne.y);
            playerTwo.transform.position = new Vector2(FirstPosPlayerTwo.x, FirstPosPlayerTwo.y);
            transform.position = new Vector2(-FirstPosBall.x,FirstPosBall.y);
            playerOneText.text = "Player 1:" + player1.ToString();

            Time.timeScale = 0;


        }
        if (collision.tag == "rightWall")
        {
            player1++;
            playerOne.transform.position = new Vector2(FirstPosPlayerOne.x, FirstPosPlayerOne.y);
            playerTwo.transform.position = new Vector2(FirstPosPlayerTwo.x, FirstPosPlayerTwo.y);
            transform.position = new Vector2(FirstPosBall.x, FirstPosBall.y);
            playerTwoText.text = "Player 2:" + player2.ToString();

            Time.timeScale = 0;

      
        }
    }
    
}
