using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMenu : MonoBehaviour
{
    public float Speed;
    public float Sensitivity;
    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed, transform.position.y, Input.GetAxisRaw("Vertical") * Speed) * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity, transform.eulerAngles.z);
        
        float x = transform.Find("Camera").eulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;
        if (x > 40)
        {
            if (x > 120)
            {
                if (x < 340) x = 340;
            }
            else x = 40;
        }
        transform.Find("Camera").eulerAngles = new Vector3(x, transform.Find("Camera").eulerAngles.y, transform.Find("Camera").eulerAngles.z);
    }
}