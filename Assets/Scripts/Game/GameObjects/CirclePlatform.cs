using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlatform : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    float angle;

    [SerializeField]
    float radius = 2f, angularSpeed = 2f;
    float positionX, positionY = 0f;

    void Update()
    {
        positionX = (float)(center.position.x + System.Math.Cos(angle) * radius);
        positionY = (float)(center.position.y + (Math.Sin(angle) * radius));
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * angularSpeed;
        if (angle >= 360f) angle = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            collision.transform.SetParent(transform);
        };
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            collision.transform.SetParent(null);
        };
    }
}
