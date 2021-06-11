using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject connectedPortal;
    public HashSet<GameObject> inPortalObjects;

    private void Start()
    {
        inPortalObjects = new HashSet<GameObject>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!inPortalObjects.Contains(collision.gameObject))
        {
            collision.gameObject.transform.position = connectedPortal.transform.position;
            connectedPortal.GetComponent<Portal>().inPortalObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inPortalObjects.Remove(collision.gameObject);
    }

}
