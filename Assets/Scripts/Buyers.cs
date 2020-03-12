using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyers : MonoBehaviour
{
    public Resource Buys;
    public Resource Money;
    public int Price;

    void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 2.5f)
        {
            Money.Amount += Price * Buys.Amount;
            Buys.Amount = 0;
            Money.Counter.text = Money.Amount.ToString();
            Buys.Counter.text = Buys.Amount.ToString();
        }
    }
}