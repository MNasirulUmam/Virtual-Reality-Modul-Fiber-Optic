using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacherAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        /*anim.SetFloat("anim", 0f);*/

        if (other.tag == "String")
        {
            anim.SetBool("open", true);
            anim.SetFloat("anim", 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetFloat("anim", 1f);
        

        if (other.tag == "String")
        {
            anim.SetBool("open", false);
            anim.SetFloat("anim", 0f);
        }
    }
}
