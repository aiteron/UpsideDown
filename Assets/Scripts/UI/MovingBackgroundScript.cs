using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-5, -5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 5 || transform.position.y < 5)
        {
            transform.position = new Vector3(transform.position.x + 0.5f*Time.deltaTime, transform.position.y + 0.5f*Time.deltaTime, 0);
        }
        else
        {
            transform.position = new Vector3(-5, -5, 0);
        }
    }
}
