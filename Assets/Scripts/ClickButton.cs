using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    public bool StartGame;

    void OnMouseDown()
    {
        StartCoroutine(DoAction());
    }

    IEnumerator DoAction()
    {
        GameObject.Find("Player").transform.Find("Camera").gameObject.SetActive(false);
        GameObject.Find("Player").transform.Find("Camera out").gameObject.SetActive(true);
        GameObject.Find("Player").transform.Find("Girl").GetComponent<Animator>().SetTrigger("Button");
        yield return new WaitForSeconds(1.5f);

        if (StartGame) SceneManager.LoadScene("Game");
        else Application.Quit();
    }
}