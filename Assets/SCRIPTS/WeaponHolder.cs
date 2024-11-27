using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    int indiceArmaActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CambiarArmaConTeclado();
        //CambiarArmaConRaton();
    }


    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0)
        {
            CambioArma(indiceArmaActual - 1);

        }

        else if (scrollWheel < 0)
        {
            CambioArma(indiceArmaActual + 1); 
        }
    }

    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambioArma(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambioArma(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambioArma(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambioArma(3);
        }
    }

    private void CambioArma(int nuevoIndice)
    {
        armas[indiceArmaActual].SetActive(false);

        //solo si es un indice valido... puedo cambiar de arma

        if (nuevoIndice >=0 && nuevoIndice < armas.Length)
        {
            //despues, cambioel indice
            indiceArmaActual = nuevoIndice;

            armas[indiceArmaActual].SetActive(true);
        }
    }





}
