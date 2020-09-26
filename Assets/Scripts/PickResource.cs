using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickResource : MonoBehaviour
{
    public Resource Res;

    void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 3.5f)
        {
            Res.Amount++;
            Res.Counter.text = Res.Amount.ToString();
            Destroy(gameObject);
        }
    }
}