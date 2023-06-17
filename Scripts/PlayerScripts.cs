using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public float speed;
    void Update()
    {
        playerMove();
    }
    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTwo.transform.Translate(new Vector3(0f, 1 * speed*Time.deltaTime, 0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTwo.transform.Translate(new Vector3(0f, -1 * speed * Time.deltaTime, 0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerOne.transform.Translate(new Vector3(0f, 1 * speed * Time.deltaTime, 0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerOne.transform.Translate(new Vector3(0f, -1 * speed * Time.deltaTime, 0f));
        }

        playerOne.transform.position = new Vector3(playerOne.transform.position.x, 
            Mathf.Clamp(playerOne.transform.position.y, -4.3f, 4.3f), 
            playerOne.transform.position.z);

       playerTwo.transform.position = new Vector3(playerTwo.transform.position.x,
             Mathf.Clamp(playerTwo.transform.position.y, -4.3f, 4.3f),
             playerTwo.transform.position.z);

    }
}
