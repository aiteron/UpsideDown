using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    float velocity = 0.02f;

    private bool isOpen = false;
    private bool cantMove = false;
    private Vector3 openPos;
    private Vector3 closePos;    

    void Awake()
    {
        var openPosTransform = transform.Find("OpenPos").transform;
        openPos = new Vector3(openPosTransform.position.x, openPosTransform.position.y, transform.position.z);
        
        var closePosTransform = transform.Find("ClosePos").transform;
        closePos = new Vector3(closePosTransform.position.x, closePosTransform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (cantMove)
            return;

        if(isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPos, velocity);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closePos, velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            cantMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        cantMove = false;
    }

    public void SetOpen(bool state)
    {
        isOpen = state;
        cantMove = false;
    }
}
