using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    // find next target and go.

    AIDestinationSetter destinationSetter;
    List<Item> itemMoneys = new List<Item>();
    private void Awake()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
    }
    private void Start()
    {
        Item[] temp_itemMoneys = FindObjectsOfType<Item>();
        itemMoneys.AddRange(temp_itemMoneys);


        FindNext();
    }

    public void FindNext()
    {
        // 가장 가깝고 우측에 있는 녀석들 중에 하나를 골라온다.






    }

    public Item GetNearestItem()
    {
        Item return_item = null;




        return return_item;
    }

}
