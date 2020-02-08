using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Health : MonoBehaviour
{
    public Vector3 startPos = new Vector3();
    public bool main_char = false;
    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Danger")
        {
            Die();
        }
    }
    public void Die()
    {
        //effect
        //return
        if (main_char)
        {
            transform.position = startPos;
            FindObjectOfType<DestinationChanger>().transform.position = startPos;
            
        }
        else
        {
            transform.position = startPos;
        }


    }
}
