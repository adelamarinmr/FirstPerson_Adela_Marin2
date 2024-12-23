using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //VARIABLE ESTATICA PARA LLAMARLA DESDE CUALQUIER PUNTO 
    public static Settings instance;

    [Header("Canvas")]
    [SerializeField] private GameObject completeCanva;
    [SerializeField] private Slider slider;
    private bool auxCanva=false;

    [Header("Musica y SFX")]
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip[] musica;


    
    void Awake()
    {
        //SI EL TRONO ESTA VACIO
        if (instance == null)
        {

            //YO ME LLEVO EL TRONO
            instance = this;
            //No nos destruimos entre escenas
            DontDestroyOnLoad(gameObject);
            

        }
        else
        {
            //SI EL TRONO ESTA OCUPADO ME AUTODESTRUYO
            Destroy(this.gameObject);
        }
        //No nos destruimos entre escenas
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        PlayMusic();
        VolumeControll();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnOffMenu();
        }

    }
    private void PlayMusic()
    {
        //SI NO SE ESTA REPRODUCIENDO LA MUSICA
        if(!audioS.isPlaying)
        {
            audioS.PlayOneShot(musica[Random.Range(0,musica.Length)]);
        }
    }

    private void VolumeControll()
    {
        audioS.volume=slider.value;
    }

    public void OnOffMenu()
    {
        //BOOL AUXILIAR QUE VA CAMBIANDO CON CADA LLAMADA A LA FUNCION PARA APAGAR O ENCENDER EL OBJETO COMPLETO
        auxCanva=!auxCanva;
        completeCanva.SetActive(auxCanva);
        //PONEMOS LA ESCALA DE TIEMPO A 1 o 0 DEPENDIENDO SI QUEREMOS PAUSAR O CONTINUAR EL JUEGO
        if(auxCanva==true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        

    }


    public void Play()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CargarNivel(int idNivel)
    {
        SceneManager.LoadScene(idNivel);
    }

}
