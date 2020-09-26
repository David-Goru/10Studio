using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Producer : MonoBehaviour
{
    public string Production;
    public int Amount;

    public string SecondaryProduction;
    public int SecondaryAmount;

    void OnMouseDown()
    {
        GameObject.Find("Main Camera").GetComponent<Build>().StartMoving(gameObject);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > 3) return;
            Transform ui = GameObject.Find("UI").transform.Find("Producer");
            ui.Find("Resource 1").GetComponent<Image>().sprite = Master.ResourcesList[Production].Sprite;
            ui.Find("Amount 1").GetComponent<Text>().text = Amount.ToString();
            ui.Find("Resource 2").GetComponent<Image>().sprite = Master.ResourcesList[SecondaryProduction].Sprite;
            ui.Find("Amount 2").GetComponent<Text>().text = SecondaryAmount.ToString();
            ui.Find("Collect").GetComponent<Button>().onClick.RemoveAllListeners();
            ui.Find("Collect").GetComponent<Button>().onClick.AddListener(TakeResources);
            ui.gameObject.SetActive(true);            
        }
    }

    public void  TakeResources()
    {
        if (Amount > 0)
        {
            Transform ui = GameObject.Find("UI").transform.Find("Producer");
            Master.ResourcesList[Production].Amount += Amount;
            Master.ResourcesList[Production].Counter.text = Master.ResourcesList[Production].Amount.ToString();
            Amount = 0;
            ui.Find("Amount 1").GetComponent<Text>().text = Amount.ToString();

            if (SecondaryAmount > 0)
            {
                Master.ResourcesList[SecondaryProduction].Amount += SecondaryAmount;
                Master.ResourcesList[SecondaryProduction].Counter.text = Master.ResourcesList[SecondaryProduction].Amount.ToString();
                SecondaryAmount = 0;
                ui.Find("Amount 2").GetComponent<Text>().text = SecondaryAmount.ToString();
            }
        }
    }

    public void EnableProduction()
    {
        gameObject.GetComponent<MeshCollider>().enabled = true;
        StartCoroutine(DoCycle());
    }

    IEnumerator DoCycle()
    {
        yield return new WaitForSeconds(3);
        Amount++;
        if(Random.Range(0, 100) > 90) SecondaryAmount++;

        StartCoroutine(DoCycle());
    }
}