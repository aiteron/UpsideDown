using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemResizeAnimation : MonoBehaviour
{
    private bool resizeToBig;
    
    void FixedUpdate()
    {
        if(resizeToBig)
        {
            transform.localScale = (new Vector3(transform.localScale.x * 1.01f, transform.localScale.y * 1.01f, transform.localScale.z));
            if (transform.localScale.x > 1.2f)
            {
                resizeToBig = false;
            }
        }
        else
        {
            transform.localScale = (new Vector3(transform.localScale.x * 0.99f, transform.localScale.y * 0.99f, transform.localScale.z));
            if (transform.localScale.x < 1f)
            {
                resizeToBig = true;
            }
        }
    }
}
