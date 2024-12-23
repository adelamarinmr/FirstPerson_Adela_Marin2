using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header ("Spawn")]
    // Spawnear cada 2 seg un enemigo aleatorio entre distintis puntos
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;

    [SerializeField] private int timeMax;
    [SerializeField] private int timeMin;

    void Start()
    {
        StartCoroutine(SpawnLogic());
        
    }
    private void Update()
    {
        
    }

    //SISTEMA DE SPAWNS
    private IEnumerator SpawnLogic()
    {
        Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity); 
        while (true)
        {
            int auxTimer=Random.Range(timeMin,timeMax);
            yield return new WaitForSeconds(auxTimer);
            Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity); // rotación = (0,0,0) multiplicas por la matriz identidad
            // saca una copia del enemy en el punto 0 con rotación 000
        }
  
    }

}
