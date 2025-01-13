using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{

    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        // cam es la cámara principal de la escena "MainCamera"
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Disparo manual");
            system.Play(); //ejecutar sistema particulas
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo,misDatos.distanciaAtaque))
            {
                Debug.Log(hitinfo.transform.name);
               
                if (hitinfo.transform.CompareTag("EnemyPart"))
                {
                    hitinfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }
            }
        }
    }
}
