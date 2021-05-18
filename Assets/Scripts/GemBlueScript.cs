using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBlueScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player1Controller>().AddGem();
            Destroy(transform.gameObject);
        }
    }
}
