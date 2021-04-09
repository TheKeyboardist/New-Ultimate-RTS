using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Spawner : MonoBehaviour
{




    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject Low_Poli_Enemy_Prefab;
    [SerializeField] GameObject BOSS;
    [SerializeField] float minDelay;
    [SerializeField] float MaxDelay;
    Transform SpawnVolume;
    Script_SpawnManager SpawnMana;
    Vector3 CenterPos;
    float MaxXPos;
    float MaxZPos;
    public int waveNum = 1;
    bool keepSpawning = true;
    int wave1 =  2;
    int wave2 = 5;
    int wave3 = 10;
    int enemiesSpawned = 0;




    // Start is called before the first frame update
    void Start()
    {
        SpawnVolume = transform.GetChild(0);
        CenterPos = new Vector3(SpawnVolume.position.x, SpawnVolume.position.y - SpawnVolume.localScale.y/2, SpawnVolume.position.z);
        MaxXPos = SpawnVolume.localScale.x/2;
        MaxZPos = SpawnVolume.localScale.z/2;
        Destroy(SpawnVolume.gameObject);
        SpawnMana = FindObjectOfType<Script_SpawnManager>();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (keepSpawning)
        {
            if ((enemiesSpawned >= wave1 && waveNum == 1) || (enemiesSpawned >= wave2 && waveNum == 2) || (enemiesSpawned >= wave3 && waveNum == 3))
            {

                if (waveNum < 3)
                    waveNum++;
                Debug.Log("wave: " + waveNum);
                StartCoroutine(DelayWaves());
            }
            else if(enemiesSpawned >= wave3 && waveNum == 3)
            {
                keepSpawning = false;
                Debug.Log("final wave finihsed");
            }


            yield return new WaitForSeconds(Random.Range(minDelay, MaxDelay));
            Vector3 Pos = new Vector3(Random.Range(-MaxXPos, MaxXPos), 0.0f, Random.Range(-MaxZPos, MaxZPos));
            int enemyRand = Random.Range(1, 4);
            Debug.Log(enemyRand);

            if (enemyRand == 1)
            {
                Instantiate(EnemyPrefab, CenterPos + Pos, new Quaternion());
                enemiesSpawned++;
                Debug.Log(enemiesSpawned + "ENEMIES SPAWNED");
                
            }
            else if (enemyRand == 2)
            {
                Instantiate(Low_Poli_Enemy_Prefab, CenterPos + Pos, new Quaternion());
                enemiesSpawned++;
                Debug.Log(enemiesSpawned + "ENEMIES SPAWNED");
                
            }
            else
            {
                Instantiate(BOSS, CenterPos + Pos, new Quaternion());
                enemiesSpawned++;
                Debug.Log(enemiesSpawned + "ENEMIES SPAWNED");

            }


            
        }
        
    }

    IEnumerator DelayWaves()
    {
        Debug.Log("wave finished");
        keepSpawning = false;
        yield return new WaitForSeconds(1.0f);
        keepSpawning = true;
    }


}
