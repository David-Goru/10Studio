using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Merchant : MonoBehaviour
{
    string resource;
    string product;
    int price;
    bool hasResource;

    void Start()
    {
        hasResource = false;
        int choose = Random.Range(0, 4);
        Debug.Log(choose);
        switch(choose)
        {
            case 0: // Tree machine
                product = "Tree machine";
                resource = "Trunk";
                price = Random.Range(25, 40);
                break;
            case 1: // Stick machine
                product = "Stick machine";
                resource = "Stick";
                price = Random.Range(10, 20);
                break;
            case 2: // Rock machine
                product = "Rock machine";
                resource = "Rock";
                price = Random.Range(25, 40);
                break;
            case 3: // Pebble machine
                product = "Pebble machine";
                resource = "Pebble";
                price = Random.Range(10, 20);
                break;
            case 4: // Pebble machine
                product = "Pebble machine";
                resource = "Pebble";
                price = Random.Range(10, 20);
                break;
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1) || EventSystem.current.IsPointerOverGameObject()) return;
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > 3) return;
        Transform ui = GameObject.Find("UI").transform.Find("Merchant");
        ui.Find("Resource").gameObject.GetComponent<Image>().sprite = Master.ResourcesList[resource].Sprite;
        ui.Find("Resource").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        ui.Find("Product").gameObject.GetComponent<Image>().sprite = Master.ProductsList[product].Sprite;
        ui.Find("Product").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        ui.Find("Price").gameObject.GetComponent<Text>().text = price.ToString();

        ui.Find("Resource").gameObject.GetComponent<Button>().onClick.AddListener(AddResource);
        ui.Find("Product").gameObject.GetComponent<Button>().onClick.AddListener(Buy);
        ui.Find("Close").gameObject.GetComponent<Button>().onClick.AddListener(Close);

        ui.gameObject.SetActive(true);
    }

    public void AddResource()
    {
        if (Master.ResourcesList[resource].Amount > 0 && Master.GlobalMoney.Amount >= price)
        {
            Transform ui = GameObject.Find("UI").transform.Find("Merchant");
            ui.Find("Resource").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            ui.Find("Product").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hasResource = true;
        }
    }

    public void Buy()
    {
        if (hasResource && Master.GlobalMoney.Amount >= price && Master.AddToInventory(Master.ProductsList[product]))
        {
            Master.GlobalMoney.Amount -= price;
            Master.GlobalMoney.Counter.text = Master.GlobalMoney.Amount.ToString();
            Master.ResourcesList[resource].Amount--;
            Master.ResourcesList[resource].Counter.text = Master.ResourcesList[resource].Amount.ToString();
            Transform ui = GameObject.Find("UI").transform.Find("Merchant");
            ui.Find("Resource").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            ui.Find("Product").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            hasResource = false;
        }
    }

    public void Close()
    {
        Transform ui = GameObject.Find("UI").transform.Find("Merchant");
        ui.Find("Resource").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        ui.Find("Product").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        ui.Find("Resource").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        ui.Find("Product").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        hasResource = false;
        ui.gameObject.SetActive(false);
    }
}