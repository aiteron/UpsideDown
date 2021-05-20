using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNormalScript : MonoBehaviour
{
    public Sprite spriteClosed;
    public Sprite spriteOpen;
    public int gemsCountNeed;
    public bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            if (collision.gameObject.GetComponent<Player1Controller>().GetGemsCount() >= gemsCountNeed)
            {
                isOpen = true;
                transform.GetComponent<SpriteRenderer>().sprite = spriteOpen;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            isOpen = false;
            transform.GetComponent<SpriteRenderer>().sprite = spriteClosed;
        }
    }
}
