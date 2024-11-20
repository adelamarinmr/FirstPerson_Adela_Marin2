using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        timer = misDatos.cadenciaAtaque;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;


        if(Input.GetMouseButton(0) && timer>= misDatos.cadenciaAtaque)
        {


            if (Input.GetMouseButtonDown(0))
            {
                system.Play(); //ejecutar sistema particulas
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
                {
                    Debug.Log(hitinfo.transform.name);

                    if (hitinfo.transform.CompareTag("EnemyPart"))
                    {
                        hitinfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                    }
                }
            }

            timer = 0;
        }
    }
}
