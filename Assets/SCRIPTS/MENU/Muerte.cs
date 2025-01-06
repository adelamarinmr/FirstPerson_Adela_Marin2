using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Muerte : MonoBehaviour
{
    public float timeRemaining = 3600f; // Tiempo inicial (1 hora)
    public TextMeshProUGUI timerText; // Objeto de texto para mostrar el temporizador
    private bool isGameOver = false; // Bandera para saber si terminó el juego


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }


        if (!isGameOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Reducir tiempo restante
                UpdateTimerUI(); // Actualizar el texto del temporizador
            }
            else
            {
                timeRemaining = 0;
                isGameOver = true;
                GameOver(); // Cambiar a pantalla de Game Over
            }
        }
    }



    void UpdateTimerUI()
    { // Convertir el tiempo restante a formato HH:MM:SS
        int hours = Mathf.FloorToInt(timeRemaining / 3600);
        int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void GameOver()
    {
        // Cambiar a la escena de Game Over
        SceneManager.LoadScene("Muerte");
    }
}
