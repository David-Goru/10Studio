using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public string Direction;
    GameObject room;

    void Start()
    {
        if (Physics.CheckSphere(transform.Find("Check room").position, 0.5f, 1 << LayerMask.NameToLayer("Room")))
            room = Physics.OverlapSphere(transform.Find("Check room").position, 0.5f, 1 << LayerMask.NameToLayer("Room"))[0].transform.parent.gameObject;
        else Destroy(gameObject);
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 2.5f)
        {
            Master.Player.transform.LookAt(new Vector3(transform.position.x, Master.Player.transform.position.y, transform.position.z));
            if (Direction == "Down right" || Direction == "Down left")
            {
                Master.Player.transform.position = room.transform.Find(Direction).position;
                Camera.main.transform.position = room.transform.Find("Camera position").position;
                StartCoroutine(Master.Player.GetComponent<Movement>().DoAnim("Fall"));
            }
            else
            {
                StartCoroutine(Master.Player.GetComponent<Movement>().DoAnim("Climb"));
                StartCoroutine(Climb());
            }
        }
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.75f);
        Master.Player.transform.position = room.transform.Find(Direction).position;
        Camera.main.transform.position = room.transform.Find("Camera position").position;
    }
}