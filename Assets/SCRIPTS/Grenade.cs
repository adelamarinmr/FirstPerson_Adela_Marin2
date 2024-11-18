using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;


    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private float radioExplosion;

    [SerializeField] GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized*fuerzaImpulso, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);



        //que la granada detecte todos los colliders dañables en un cierto radio de explosion, incluir un if
        // un if para ver si al menos hemos dañado un collider
       Collider[] collsDetectados= Physics.OverlapSphere(transform.position, radioExplosion, queEsDanhable);

        if(collsDetectados.Length > 0)
        {
            Debug.Log("Adios enemy");
        }
    }
}
