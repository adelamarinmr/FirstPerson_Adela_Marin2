using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunición : MonoBehaviour
{
    private Animator anim;
    private bool open=false;

    private void Start()
    {
        open =false;
        anim = GetComponent<Animator>();    
    }


    public bool Abrir()
    {
        if(!open)
        {
            anim.SetTrigger("Abrir");
            Debug.Log("Caja: "+gameObject.name+" ha sido abierta.");
            open = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
