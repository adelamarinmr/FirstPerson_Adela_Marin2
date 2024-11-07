using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{

    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            system.Play();
        }
    }
}
