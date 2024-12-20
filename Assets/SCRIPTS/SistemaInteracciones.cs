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
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.TryGetComponent(out CajaMunición scriptCaja))
            {
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;


                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptCaja.Abrir();
                }

            }

            //si tenia un interactuable 
            else if (interactuableActual)
            {   //le apago...
                interactuableActual.GetComponent<Outline>().enabled = false;

                //Le anulo
                interactuableActual = null;
            }

        }
    }
}