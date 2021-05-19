using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public PlatformScript platform;

    private bool isLeverOn = false;
    private bool isPlayer1Collision = false;
    private bool isPlayer2Collision = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            isPlayer1Collision = true;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            isPlayer2Collision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            isPlayer1Collision = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            isPlayer2Collision = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer1Collision)
        {
            isLeverOn = !isLeverOn;
            platform.SetOpen(isLeverOn);
            if (!isLeverOn)
                transform.localScale = new Vector3(1, transform.localScale.y, 1);
            else
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightControl) && isPlayer2Collision)
        {
            isLeverOn = !isLeverOn;
            platform.SetOpen(isLeverOn);
            if (!isLeverOn)
                transform.localScale = new Vector3(1, transform.localScale.y, 1);
            else
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
    }
}
