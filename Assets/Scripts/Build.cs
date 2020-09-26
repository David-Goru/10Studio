using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Build : MonoBehaviour
{
    int objectToPlace;
    GameObject objectModel;
    Vector3 lastPos;
    int rot;
    bool moving;
    bool justClicked;

    void Update()
    {
        if (!moving && EventSystem.current.IsPointerOverGameObject())
        { 
            if (objectModel != null) Destroy(objectModel);
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.R) && objectModel)
        {
            rot += 90;
            if (rot == 360) rot = 0;
            objectModel.transform.rotation = Quaternion.Euler(0, rot, 0);

            Vector3 pos = new Vector3(lastPos.x, lastPos.y, lastPos.z);
            Vector3 vPos = new Vector3(Mathf.Round(lastPos.x * 4.0f) / 4.0f, lastPos.y, Mathf.Round(lastPos.z * 4.0f) / 4.0f);
            checkObjectPos(pos, vPos);
        }

        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Vector3 vPos = new Vector3(Mathf.Round(hit.point.x * 4.0f) / 4.0f, lastPos.y, Mathf.Round(hit.point.z * 4.0f) / 4.0f);
            if (objectModel == null)
            {
                objectModel = (GameObject)Instantiate(Master.Inventory[objectToPlace].Model, pos, Quaternion.Euler(0, rot, 0));
                lastPos = pos;
                objectModel.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (lastPos != pos && lastPos != vPos) checkObjectPos(pos, vPos);
        }
        else if (objectModel && !moving) Destroy(objectModel);
        
        if (Input.GetMouseButtonDown(0) && !justClicked && objectModel && objectModel.GetComponent<Renderer>().material.color == Color.green)
        {
            objectModel.GetComponent<Renderer>().material.color = Color.white;
            if (!moving)
            {
                Master.RemoveFromInventory(objectToPlace);
                objectModel.GetComponent<Producer>().EnableProduction();
            }
            else objectModel.GetComponent<MeshCollider>().enabled = true;
            objectModel = null;
            enabled = false;
        }
        justClicked = false;
    }

    void checkObjectPos(Vector3 pos, Vector3 vPos)
    {
        bool placeable = true;
        
        if (Physics.OverlapSphere(vPos, 0.25f, 1 << LayerMask.NameToLayer("Object")).Length > 0) placeable = false;

        if (placeable)
        {
            lastPos = vPos;
            objectModel.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            lastPos = pos;
            objectModel.GetComponent<Renderer>().material.color = Color.red;
        }
        
        objectModel.transform.position = lastPos;
    }

    public void StartBuilding(int i)
    {
        objectToPlace = i;
        moving = false;
        enabled = true;
        justClicked = false;
    }

    public void StartMoving(GameObject model)
    {
        objectModel = model;
        model.GetComponent<MeshCollider>().enabled = false;
        moving = true;
        enabled = true;
        justClicked = true;
    }

    public void CloseObjectsBuilding()
    {
        Destroy(objectModel);
        enabled = false;
    }
}