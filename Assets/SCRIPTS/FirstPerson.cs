using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    [SerializeField] private float escalaGravedad;
    private Vector3 movimientoVertical; // para mod mi vel en caida libre y mi vel en los saltos
    
    

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       float h =  Input.GetAxisRaw("Horizontal"); //h=0, h=-1, h=1
       float v =  Input.GetAxisRaw("Vertical");
       Vector2 input = new Vector2(h, v).normalized;

        //siexiste input esq rota
        if(input.magnitude>0)
        { 
            //se calcula el ángulo al que tengo que rotarme en funcion de los inputs y orientacion de camara
            float anguloRotacion= Mathf.Atan2(input.x,input.y)*Mathf.Rad2Deg+Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0,anguloRotacion,0)*Vector3.forward;
            controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);

        }


    }
    private void AplicarGravedad()
    {

    }






}
