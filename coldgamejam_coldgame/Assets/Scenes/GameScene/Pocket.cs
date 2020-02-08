using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    public double money = 0.0f;
    public Health health;
    public Text txt_money;
    private void Awake()
    {
        health = GetComponent<Health>();

    }
    private void Start()
    {
        UpdateMoneyText();
    }
    public bool UpdateMoney(double value, bool up)
    {
        if(up)
        {
            money += value;
            return true;
        }
        else
        {
            if(money > value) {
                money -= value;
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public void UpdateMoneyText()
    {
        txt_money.text = "$"+money.ToString("F0");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Money")
        {
            Item itemMoney = collision.gameObject.GetComponent<Item>();
            if(itemMoney.DEAD == false)
            {
                UpdateMoney(itemMoney.value, true);
                UpdateMoneyText();
                itemMoney.Gone();
                if(health.main_char ==false)
                {
                    GetComponent<Enemy>().FindNext();
                }
            }

        }
    }
}
