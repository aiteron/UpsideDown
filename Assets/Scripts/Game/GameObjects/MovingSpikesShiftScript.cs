using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikesShiftScript : MonoBehaviour
{
    public SpikesSide side;

    GameObject player1;
    GameObject player2;
    public GameObject platform;
    Vector3 openPosition;
    Vector3 closePositon;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        openPosition = transform.position - platform.transform.position;

        if (side == SpikesSide.Down)
        {
            closePositon = new Vector3(openPosition.x, openPosition.y + 0.5f, openPosition.z);
        }
        else if (side == SpikesSide.Up)
        {
            closePositon = new Vector3(openPosition.x, openPosition.y - 0.5f, openPosition.z);
        }
        else if (side == SpikesSide.Left)
        {
            closePositon = new Vector3(openPosition.x + 0.5f, openPosition.y, openPosition.z);
        }
        else
        {
            closePositon = new Vector3(openPosition.x - 0.5f, openPosition.y, openPosition.z);
        }
        transform.position = platform.transform.position;
    }

    bool CorrectSideCheck(Vector3 spikes, Vector3 player)
    {
        if (side == SpikesSide.Down)
        {
            return spikes.y > player.y;
        }
        else if (side == SpikesSide.Up)
        {
            return spikes.y < player.y;
        }
        else if (side == SpikesSide.Left)
        {
            return spikes.x > player.x;
        }
        else
        {
            return spikes.x < player.x;
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player1.transform.position) < 2 && CorrectSideCheck(transform.position, player1.transform.position) 
            || Vector3.Distance(transform.position, player2.transform.position) < 2 && CorrectSideCheck(transform.position, player2.transform.position))
        {
            
            transform.position = Vector3.Lerp(transform.position, platform.transform.position + openPosition, 0.1f);           
        }
        else
        {
            if (Vector3.Distance(transform.position, platform.transform.position + closePositon) > 1)
            {
                transform.position = platform.transform.position + closePositon;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, platform.transform.position + closePositon, 0.1f);
            }
        }
    }
}
