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
        if (lastAnim == "Fall" || lastAnim == "Climb") return;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - Input.GetAxis("Horizontal"), transform.position.y, transform.position.z), Speed * Time.deltaTime);
            if (Input.GetAxis("Horizontal") > 0 && (lastAnim != "Move" || animDir != "Right"))
            {
                lastAnim = "Move";
                animDir = "Right";
                transform.rotation = Quaternion.Euler(0, -90, 0);
                anim.SetTrigger("Walk");
            }
            else if (Input.GetAxis("Horizontal") < 0 && (lastAnim != "Move" || animDir != "Left"))
            {
                lastAnim = "Move";
                animDir = "Left";
                transform.rotation = Quaternion.Euler(0, 90, 0);
                anim.SetTrigger("Walk");
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - Input.GetAxis("Vertical")), Speed * 4 * Time.deltaTime);
            if (Input.GetAxis("Vertical") > 0 && (lastAnim != "Move" || animDir != "Down"))
            {
                lastAnim = "Move";
                animDir = "Down";
                transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetTrigger("Walk");
            }
            else if (Input.GetAxis("Vertical") < 0 && (lastAnim != "Move" || animDir != "Up"))
            {
                lastAnim = "Move";
                animDir = "Up";
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetTrigger("Walk");
            }
        }
        else if (lastAnim != "Idle")
        {
            lastAnim = "Idle";
            animDir = "None";
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }
    }

    public IEnumerator DoAnim(string animation)
    {
        lastAnim = animation;
        anim.SetTrigger(animation);
        yield return new WaitForSeconds(0.75f);
        lastAnim = "None";
    }
}