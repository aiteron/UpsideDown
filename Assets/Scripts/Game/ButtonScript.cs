using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Sprite pressedSprite;
    public Sprite unpressedSprite;
    public PlatformScript platform;

    private HashSet<GameObject> collisionSet;

    private void Awake()
    {
        collisionSet = new HashSet<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionSet.Count == 0)
        {
            var sprite = transform.GetComponent<SpriteRenderer>();
            sprite.sprite = pressedSprite;
            platform.SetOpen(true);
        }

        collisionSet.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionSet.Remove(collision.gameObject);

        if (collisionSet.Count == 0)
        {
            var sprite = transform.GetComponent<SpriteRenderer>();
            sprite.sprite = unpressedSprite;
            platform.SetOpen(false);
        }
    }
}
