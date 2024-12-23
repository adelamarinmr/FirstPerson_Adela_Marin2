using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunición : MonoBehaviour
{
     private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }


    public void Abrir()
    {
        anim.SetTrigger("Abrir");

    }
}
