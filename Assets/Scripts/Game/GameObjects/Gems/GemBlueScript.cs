using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBlueScript : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player1Controller>().AddGem();
            Destroy(transform.gameObject);
            collectSound.Play();
        }
    }
}
