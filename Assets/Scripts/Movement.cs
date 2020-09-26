using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    string lastAnim = "Idle";
    string animDir ="Down";
    Animator anim;

    void Start()
    {
        anim = transform.Find("Model").gameObject.GetComponent<Animator>();
        StartCoroutine(Master.Player.GetComponent<Movement>().DoAnim("Fall"));
    }

    void FixedUpdate()
    {
        if (lastAnim == "Fall" || lastAnim == "Climb" || lastAnim == "Turning") return;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Input.GetAxis("Horizontal") * 0.707f, transform.position.y, transform.position.z), Speed * 2 * Time.deltaTime);
                if (lastAnim != "Move" || animDir != "Down right")
                {
                    if (animDir == "Up left")
                    {
                        animDir = "Down right";
                        StartCoroutine(Turn());
                    }
                    else if (lastAnim != "Move")
                    {
                        anim.SetTrigger("Walk");   
                        lastAnim = "Move"; 
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        animDir = "Down right";
                    }            
                    else
                    {
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        animDir = "Down right";
                    }
                }
            }
            else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * 0.707f), Speed * 2 * Time.deltaTime);
                if (lastAnim != "Move" || animDir != "Up right")
                {
                    if (animDir == "Down left")
                    {
                        animDir = "Up right";
                        StartCoroutine(Turn());
                    }
                    else if (lastAnim != "Move")
                    {
                        anim.SetTrigger("Walk");
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        animDir = "Up right";
                    }
                    else
                    {
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        animDir = "Up right";
                    }
                }
            }
            else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + Input.GetAxis("Vertical") * 0.707f), Speed * 2 * Time.deltaTime);
                if (lastAnim != "Move" || animDir != "Down left")
                {
                    if (animDir == "Up right")
                    {
                        animDir = "Down left";
                        StartCoroutine(Turn());
                    }
                    else if (lastAnim != "Move")
                    {
                        anim.SetTrigger("Walk");
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, -180, 0);
                        animDir = "Down left";
                    }
                    else
                    {
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, -180, 0);
                        animDir = "Down left";
                    }
                }
            }
            else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Input.GetAxis("Horizontal") * 0.707f, transform.position.y, transform.position.z), Speed * 2 * Time.deltaTime);
                if (lastAnim != "Move" || animDir != "Up left")
                {
                    if (animDir == "Down right")
                    {
                        animDir = "Up left";
                        StartCoroutine(Turn());
                    }
                    else if (lastAnim != "Move")
                    {
                        anim.SetTrigger("Walk");
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        animDir = "Up left";
                    }
                    else
                    {
                        lastAnim = "Move";
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        animDir = "Up left";
                    }
                }
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y, transform.position.z - Input.GetAxis("Horizontal")), Speed * 2 * Time.deltaTime);
            if (Input.GetAxis("Horizontal") < 0 && (lastAnim != "Move" || animDir != "Right"))
            {
                if (animDir == "Left")
                {
                    animDir = "Right";
                    StartCoroutine(Turn());
                }
                else if (lastAnim != "Move")
                {
                    anim.SetTrigger("Walk");   
                    lastAnim = "Move"; 
                    transform.rotation = Quaternion.Euler(0, -45, 0);
                    animDir = "Right";
                }            
                else
                {
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, -45, 0);
                    animDir = "Right";
                }
            }
            else if (Input.GetAxis("Horizontal") > 0 && (lastAnim != "Move" || animDir != "Left"))
            {
                if (animDir == "Right")
                {
                    animDir = "Left";
                    StartCoroutine(Turn());
                }
                else if (lastAnim != "Move")
                {
                    anim.SetTrigger("Walk");
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, 135, 0);
                    animDir = "Left";
                }
                else
                {
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, 135, 0);
                    animDir = "Left";
                }
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Input.GetAxis("Vertical"), transform.position.y, transform.position.z + Input.GetAxis("Vertical")), Speed * 2 * Time.deltaTime);
            if (Input.GetAxis("Vertical") < 0 && (lastAnim != "Move" || animDir != "Down"))
            {
                if (animDir == "Up")
                {
                    animDir = "Down";
                    StartCoroutine(Turn());
                }
                else if (lastAnim != "Move")
                {
                    anim.SetTrigger("Walk");
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, -135, 0);
                    animDir = "Down";
                }
                else
                {
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, -135, 0);
                    animDir = "Down";
                }
            }
            else if (Input.GetAxis("Vertical") > 0 && (lastAnim != "Move" || animDir != "Up"))
            {
                if (animDir == "Down")
                {
                    animDir = "Up";                    
                    StartCoroutine(Turn());
                }
                else if (lastAnim != "Move")
                {
                    anim.SetTrigger("Walk");
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, 45, 0);
                    animDir = "Up";
                }
                else
                {
                    lastAnim = "Move";
                    transform.rotation = Quaternion.Euler(0, 45, 0);
                    animDir = "Up";
                }
            }
        }
        else if (lastAnim != "Idle")
        {
            lastAnim = "Idle";
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }
    }

    IEnumerator Turn()
    {
        lastAnim = "Turning";
        anim.SetTrigger("Turn");
        yield return new WaitForSeconds(1.05f);

        if (animDir == "Up") transform.rotation = Quaternion.Euler(0, 45, 0);
        else if (animDir == "Down") transform.rotation = Quaternion.Euler(0, -135, 0);
        else if (animDir == "Left") transform.rotation = Quaternion.Euler(0, 135, 0);
        else if (animDir == "Right") transform.rotation = Quaternion.Euler(0, -45, 0);
        else if (animDir == "Down right") transform.rotation = Quaternion.Euler(0, -90, 0);
        else if (animDir == "Up right") transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (animDir == "Down left") transform.rotation = Quaternion.Euler(0, -180, 0);
        else if (animDir == "Up left") transform.rotation = Quaternion.Euler(0, 90, 0);
        anim.SetTrigger("Walk");
        lastAnim = "Move";
    }

    public IEnumerator DoAnim(string animation)
    {
        lastAnim = animation;
        anim.SetTrigger(animation);
        yield return new WaitForSeconds(0.75f);
        lastAnim = "None";
    }
}