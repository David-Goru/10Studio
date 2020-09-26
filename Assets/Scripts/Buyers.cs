using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buyers : MonoBehaviour
{
    public string Resource;
    public int Price;

    void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > 3 || EventSystem.current.IsPointerOverGameObject()) return;

        Transform ui = GameObject.Find("UI").transform.Find("Buyer");
        ui.Find("Resource").gameObject.GetComponent<Image>().sprite = Master.ResourcesList[Resource].Sprite;
        ui.Find("Sell 1").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        ui.Find("Sell 5").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        ui.Find("Sell 10").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        ui.Find("Sell 1").gameObject.GetComponent<Button>().onClick.AddListener(() => SellResource(1));
        ui.Find("Sell 5").gameObject.GetComponent<Button>().onClick.AddListener(() => SellResource(5));
        ui.Find("Sell 10").gameObject.GetComponent<Button>().onClick.AddListener(() => SellResource(10));
        ui.gameObject.SetActive(true);
    }

    public void SellResource(int amount)
    {
        if (Master.ResourcesList[Resource].Amount == 0) return;
        if (Master.ResourcesList[Resource].Amount < amount) amount = Master.ResourcesList[Resource].Amount;

        Master.GlobalMoney.Amount += Price * amount;
        Master.GlobalMoney.Counter.text = Master.GlobalMoney.Amount.ToString();

        Master.ResourcesList[Resource].Amount -= amount;        
        Master.ResourcesList[Resource].Counter.text = Master.ResourcesList[Resource].Amount.ToString();
    }
}