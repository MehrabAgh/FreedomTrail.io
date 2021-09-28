using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private int aliveEnemies;  
    public Transform spawnPoint; // the spawn whereabouts
    public Transform player;
    public GameObject spawnFX;
    public GameObject[] enemyPrefabs;
    private bool spawnAllowed;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    private void Update()
    {
        aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        spawnAllowed = aliveEnemies < 2; // if there's < 2 enemies alive we can spawn new ones
    }

    private IEnumerator spawn()
    {
       
        while (true)
        {
            if(spawnAllowed)
            {
            print("spawning");

            // wait for some seconds before spawning new enemies
            float delay = Random.Range(1, 5);
            yield return new WaitForSeconds(delay);

            

            Vector3 pos = spawnPoint.position + (Vector3.right * Random.Range(-1,1)* 5);

            Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], pos,
            Quaternion.Euler(new Vector3(0, 180, 0))); 

            Instantiate(spawnFX, pos, Quaternion.identity); // spawn effect

            }
            else
            {
                yield return null;                
            }
        }
    }

}
