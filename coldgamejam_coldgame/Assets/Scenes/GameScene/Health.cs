﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Health : MonoBehaviour
{
    public Vector3 startPos = new Vector3();
    public bool main_char = false;
    public GameObject die_particle;
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
        GetComponent<AudioSource>().Play();
        Instantiate(die_particle).transform.position = transform.position;
        transform.position = startPos;
    }
}
