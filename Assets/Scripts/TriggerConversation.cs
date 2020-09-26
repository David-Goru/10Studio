using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TriggerConversation : MonoBehaviour
{
    public string[] Texts;
    int currentText;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > 3) return;
            Transform converHandler = GameObject.Find("UI").transform.Find("Conversation");
            if (converHandler.gameObject.activeSelf) return;
            Debug.Log("4");
            currentText = 0;
            converHandler.Find("Text").gameObject.GetComponent<Text>().text = Texts[0];
            converHandler.Find("Button").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            converHandler.Find("Button").gameObject.GetComponent<Button>().onClick.AddListener(delegate() { NextText(); });
            converHandler.gameObject.SetActive(true);
        }
    }

    public void NextText()
    {
        currentText++;
        Transform converHandler = GameObject.Find("UI").transform.Find("Conversation");
        if (currentText == Texts.Length) converHandler.gameObject.SetActive(false);
        else converHandler.Find("Text").gameObject.GetComponent<Text>().text = Texts[currentText];
    }
}