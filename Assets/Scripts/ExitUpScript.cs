using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUpScript : MonoBehaviour
{
    public Sprite spriteClosed;
    public Sprite spriteOpen;
    public int gemsCountNeed;
    public bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            if (collision.gameObject.GetComponent<Player2Controller>().GetGemsCount() >= gemsCountNeed)
            {
                isOpen = true;
                transform.GetComponent<SpriteRenderer>().sprite = spriteOpen;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            isOpen = false;
            transform.GetComponent<SpriteRenderer>().sprite = spriteClosed;
        }
    }
}
