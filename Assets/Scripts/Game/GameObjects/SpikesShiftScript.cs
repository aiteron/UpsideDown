using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpikesSide
{
    Left,
    Right,
    Up,
    Down
}

public class SpikesShiftScript : MonoBehaviour
{
    public SpikesSide side;

    GameObject player1;
    GameObject player2;
    Vector3 openPosition;
    Vector3 closePositon;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        openPosition = transform.position;

        if (side == SpikesSide.Down)
        {
            closePositon = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
        else if (side == SpikesSide.Up)
        {
            closePositon = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }
        else if (side == SpikesSide.Left)
        {
            closePositon = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }
        else
        {
            closePositon = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
        transform.position = closePositon;
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
            transform.position = Vector3.Lerp(transform.position, openPosition, 0.05f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closePositon, 0.05f);
        }
    }
}
