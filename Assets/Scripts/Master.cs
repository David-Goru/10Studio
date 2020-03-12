using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    public Resource Money;
    public Resource Pebble;
    public Resource Stick;

    public static GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        Money.Amount = 0;
        Pebble.Amount = 0;
        Stick.Amount = 0;
        Money.Counter = GameObject.Find("UI").transform.Find("Money").Find("Text").gameObject.GetComponent<Text>();
        Pebble.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Pebble").Find("Counter").gameObject.GetComponent<Text>();
        Stick.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Stick").Find("Counter").gameObject.GetComponent<Text>();
    }
}
