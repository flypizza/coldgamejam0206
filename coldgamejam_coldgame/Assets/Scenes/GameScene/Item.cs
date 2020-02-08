using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public double value = 0.0f;
    public bool dead = false;

    public bool DEAD
    {
        get
        {
            return dead;
        }
    }
    public void Gone()
    {
        dead = true;
        GetComponent<SpriteRenderer>().gameObject.SetActive(false);
    }
}
