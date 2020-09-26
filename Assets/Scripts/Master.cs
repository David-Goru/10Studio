using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    public Resource Money;
    public Resource Pebble;
    public Resource Stick;
    public Resource Rock;
    public Resource Trunk;
    public Resource Iron;
    public Resource Sap;

    public Product StickMachine;
    public Product PebbleMachine;
    public Product TreeMachine;
    public Product RockMachine;

    public static Resource GlobalMoney;
    public static GameObject Player;
    public static Dictionary<string, Resource> ResourcesList;
    public static Dictionary<string, Product> ProductsList;

    public static Product[] Inventory;

    void Start()
    {
        Player = GameObject.Find("Player");
        Money.Amount = 0;
        Money.Counter = GameObject.Find("UI").transform.Find("Money").Find("Text").gameObject.GetComponent<Text>();
        GlobalMoney = Money;
        
        ResourcesList = new Dictionary<string, Resource>();
        Pebble.Amount = 0;
        ResourcesList.Add("Pebble", Pebble);
        Pebble.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Pebble").Find("Counter").gameObject.GetComponent<Text>();
        Stick.Amount = 0;
        ResourcesList.Add("Stick", Stick);
        Stick.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Stick").Find("Counter").gameObject.GetComponent<Text>();
        Rock.Amount = 0;
        ResourcesList.Add("Rock", Rock);
        Rock.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Rock").Find("Counter").gameObject.GetComponent<Text>();
        Trunk.Amount = 0;
        ResourcesList.Add("Trunk", Trunk);
        Trunk.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Trunk").Find("Counter").gameObject.GetComponent<Text>();
        Iron.Amount = 0;
        ResourcesList.Add("Iron", Iron);
        Iron.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Iron").Find("Counter").gameObject.GetComponent<Text>();
        Sap.Amount = 0;
        ResourcesList.Add("Sap", Sap);
        Sap.Counter = GameObject.Find("UI").transform.Find("Materials").Find("Sap").Find("Counter").gameObject.GetComponent<Text>();

        ProductsList = new Dictionary<string, Product>();
        ProductsList.Add("Stick machine", StickMachine);
        ProductsList.Add("Pebble machine", PebbleMachine);
        ProductsList.Add("Tree machine", TreeMachine);
        ProductsList.Add("Rock machine", RockMachine);

        Inventory = new Product[3];
    }

    public static bool AddToInventory(Product p)
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == null)
            {
                Inventory[i] = p;
                GameObject.Find("UI").transform.Find("Inventory").Find("Slot " + i).gameObject.SetActive(true);
                GameObject.Find("UI").transform.Find("Inventory").Find("Slot " + i).gameObject.GetComponent<Image>().sprite = p.Sprite;
                return true;
            }
        }
        return false;
    }

    public static void RemoveFromInventory(int i)
    {
        Inventory[i] = null;
        GameObject.Find("UI").transform.Find("Inventory").Find("Slot " + i).gameObject.SetActive(false);
    }

    public void StartBuilding(int i)
    {
        if (Inventory[i] != null) gameObject.GetComponent<Build>().StartBuilding(i);
    }
}