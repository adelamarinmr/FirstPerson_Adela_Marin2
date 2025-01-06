using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Muerte : MonoBehaviour
{
    public float timeRemaining = 30f; // Tiempo inicial en segundos
    public Text timerText; // Referencia al componente UI Text
    private bool isGameOver = false; // Controla si el juego terminó


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
            // Actualizar el temporizador
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Reducir el tiempo restante
                UpdateTimerUI(); // Actualizar el texto en pantalla
            }
            else
            {
                // Cuando el tiempo se agota
                timeRemaining = 0;
                isGameOver = true;
                GameOver();
            }
        }
    }



    void UpdateTimerUI()
    { // Actualizar el texto del temporizador en formato HH:MM:SS
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
