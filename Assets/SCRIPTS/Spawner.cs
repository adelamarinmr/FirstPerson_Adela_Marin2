using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Spawnear cada 2 seg un enemigo aleatorio entre distintis puntos
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;
    void Start()
    {

        Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity); // rotación = (0,0,0) multiplicas por la matriz identidad

        // saca una copia del enemy en el punto 0 con rotación 000
    }

    
    
}
