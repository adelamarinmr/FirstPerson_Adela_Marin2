using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
   private Transform interactuableActual;
    void Start()
    {
        cam= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
       {
            if(hit.transform.CompareTag("CajaMunici�n"))
            {
                interactuableActual= hit.transform;
                interactuableActual.GetComponent<Outline>().enabled=true;
                    
            }

            else if(interactuableActual)
            {
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual= null;
            }
       }
        


    }
}
