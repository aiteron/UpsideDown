using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRedScript : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2Controller>().AddGem();
            Destroy(transform.gameObject);
            collectSound.Play();
        }
    }
}
