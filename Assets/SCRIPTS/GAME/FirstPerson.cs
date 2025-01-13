using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float vidas;
    [SerializeField] private TMP_Text txtvida;


    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
     CharacterController controller;
    [SerializeField] private float escalaGravedad;
     private Vector3 movimientoVertical; // para mod mi vel en caida libre y mi vel en los saltos
    [SerializeField] private float alturaSalto;
    private Camera cam;


    [Header("Deteccion suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        txtvida.SetText(vidas.ToString());

       float h =  Input.GetAxisRaw("Horizontal"); //h=0, h=-1, h=1
       float v =  Input.GetAxisRaw("Vertical");
       Vector2 input = new Vector2(h, v).normalized;

        //
        transform.eulerAngles= new Vector3 (0, cam.transform.eulerAngles.y, 0);

        //siexiste input esq rota
        if(input.sqrMagnitude>0)
        { 
            //se calcula el ángulo al que tengo que rotarme en funcion de los inputs y orientacion de camara
            float anguloRotacion= Mathf.Atan2(input.x,input.y)*Mathf.Rad2Deg+cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0,anguloRotacion,0)*Vector3.forward;
            controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);

        }
        AplicarGravedad();
        TocoSuelo();
    }
    private void AplicarGravedad()
    {
        // mi mov vertical en la Y va aumentandose (+=) a cierta escala por segundo
        movimientoVertical.y += escalaGravedad * Time.deltaTime;

        controller.Move(movimientoVertical*Time.deltaTime);

    }

    private void TocoSuelo()
    {
        // lanzar bola de deteccion en mis pies para detectar si hay suelo
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);
       
        //si existe al menos un collider bajo mis pies...
        if(collsDetectados.Length>0 )
        {
            movimientoVertical.y = 0;
            Saltar();

        }
    }

    private void OnDrawGizmos() // sirve para dibujar cualquier figura en la escena
    {
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
        Gizmos.color= Color.green;
    }


    private void Saltar()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            movimientoVertical.y= Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
       }
    }

    public void RecibirDano(float danoRecibido)
    {
        vidas -= danoRecibido;
        if (vidas < 0)
        {
            Settings.instance.CargarNivel(2);

        }
    }

    public void RecuperarVida(float _vida)
    {
        Debug.Log("Mis vidas eran: " + vidas);
        //RECUPERAMOS VIDAS
        vidas += _vida;
        Debug.Log("Mis vidas son: " + vidas);
    }


    private void OnTriggerEnter(Collider other)
    {
        //FALTA EL NUMERO DE ESCENA DE VICTORIA
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }

}
