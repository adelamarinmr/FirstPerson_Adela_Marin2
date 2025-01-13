using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //FALTA EL NUMERO DE ESCENA DE VICTORIA
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
