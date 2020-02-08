using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")  {

            Debug.Log("GameSet");

            GameObject winner = collision.gameObject;

            winner.GetComponent<AIDestinationSetter>().target = null;


            FindObjectOfType<DestinationChanger>().GameSet();

        }
    }
}
