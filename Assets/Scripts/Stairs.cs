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
        {
            room = Physics.OverlapSphere(transform.Find("Check room").position, 0.5f, 1 << LayerMask.NameToLayer("Room"))[0].transform.parent.gameObject;
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        else Destroy(gameObject);
    }

    void OnTriggerEnter()
    {
        transform.Find("E").gameObject.SetActive(true);
    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Master.Player.transform.LookAt(new Vector3(transform.position.x, Master.Player.transform.position.y, transform.position.z));
            if (Direction == "Down right" || Direction == "Down left")
            {
                // Enable new room models
                room.transform.Find("Model").gameObject.GetComponent<MeshRenderer>().enabled = true;
                room.transform.Find("Room items").gameObject.SetActive(true);

                Master.Player.transform.position = room.transform.Find(Direction).position;
                Camera.main.transform.position = room.transform.Find("Camera position").position;

                Master.Player.GetComponent<Movement>().StartCoroutine(Master.Player.GetComponent<Movement>().DoAnim("Fall"));

                // Disable old room models    
                transform.parent.parent.Find("Model").gameObject.GetComponent<MeshRenderer>().enabled = false;
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Master.Player.GetComponent<Movement>().StartCoroutine(Master.Player.GetComponent<Movement>().DoAnim("Climb"));
                StartCoroutine(Climb());
            }
            transform.Find("E").gameObject.SetActive(false);
        }
    }

    void OnTriggerExit()
    {
        transform.Find("E").gameObject.SetActive(false);
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.75f);

        // Enable new room models
        room.transform.Find("Model").gameObject.GetComponent<MeshRenderer>().enabled = true;
        room.transform.Find("Room items").gameObject.SetActive(true);

        Master.Player.transform.position = room.transform.Find(Direction).position;
        Camera.main.transform.position = room.transform.Find("Camera position").position;

        // Disable old room models        
        transform.parent.parent.Find("Model").gameObject.GetComponent<MeshRenderer>().enabled = false;
        transform.parent.gameObject.SetActive(false);
    }
}