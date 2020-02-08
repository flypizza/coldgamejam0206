using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChanger : MonoBehaviour
{
    public bool stop = false;
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && !stop)
        {
            Vector3 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedPos.z = 0.0f;
            transform.position = clickedPos;
        }
    }

    public void GameSet()
    {
        stop = true;
    }
}
