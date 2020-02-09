using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public double value = 0.0f;
    public bool dead = false;
    public GameObject _effect;

    public bool DEAD
    {
        get
        {
            return dead;
        }
    }
    public void Gone()
    {
        GetComponent<AudioSource>().Play();
        dead = true;
        GoEffect();
        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
    }

    public void GoEffect()
    {
        Instantiate(_effect).transform.position = transform.position;
    }
}
