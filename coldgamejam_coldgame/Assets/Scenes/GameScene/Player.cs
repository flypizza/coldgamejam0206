﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Player : MonoBehaviour
{
    // find next target and go.

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    List<Item> itemMoneys = new List<Item>();
    public Item near_item;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public GameObject GFX;

    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdatePath(Vector3 targetPos)
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, targetPos, OnPathComplete);
        }
    }


    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (path == null || gm.STATE != GAME_STATE.START)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }


        if (direction.x >= 0.01f)
        {
            GFX.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction.x <= -0.01f)
        {
            GFX.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && gm.STATE == GAME_STATE.START)
        {
            Vector2 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdatePath(touchPoint);
        }
    }
    public void FindNext()
    {
        // 가장 가깝고 우측에 있는 녀석들 중에 하나를 골라온다.

        near_item = GetNearestItem();
    }

    public Item GetNearestItem()
    {
        Item return_item = null;
        float near_dist = 9999999.0f;

        foreach (Item _item in itemMoneys)
        {
            float dist = Vector3.Distance(transform.position, _item.transform.position);
            if (dist < near_dist && _item.DEAD == false)
            {
                near_dist = dist;
                return_item = _item;
            }
        }
        return return_item;
    }

}
