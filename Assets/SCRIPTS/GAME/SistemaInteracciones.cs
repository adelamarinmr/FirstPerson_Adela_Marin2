using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    private Transform interactuableActual;
    private FirstPerson fp;

    void Start()
    {
        cam = Camera.main;
        fp=GetComponent<FirstPerson>();//ESTO VA EN EL AWAKE PORQUE BLA BLA
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

                //CAMBIO DEL FUNCIONAMIENTO DE LA CAJA PARA QUE RECUPERES VIDA
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bool aux = scriptCaja.Abrir();
                    if(aux)
                    {
                        fp.RecuperarVida(50);
                    }
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