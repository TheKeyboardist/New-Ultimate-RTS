using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNLManager : MonoBehaviour
{
    [SerializeField]
    private LevelState level;

    private static SNLManager instance;


    bool loadSave;
    bool saveExists;
    GameObject tempSpawner;


    private void Awake()
    {
        loadSave = false;
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        saveExists = false;

        StartCoroutine(LookForSpawner());
    }


    public void Save()
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        Script_Spawner spawnerScript = spawner.GetComponent<Script_Spawner>();
        level.currentWave = spawnerScript.waveNum;
        saveExists = true;
    }

    public void Load()
    {
        if (saveExists && loadSave)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < spawners.Length; i++)
            {
                Script_Spawner tempScriptRef = spawners[i].GetComponent<Script_Spawner>();
                tempScriptRef.waveNum = level.currentWave;
            }
        }
        else
        {
            Debug.Log("Nothing has been previously saved");
        }

    }

    IEnumerator LookForSpawner()
    {

        if (tempSpawner == null)
            tempSpawner = GameObject.FindGameObjectWithTag("Spawner");
        else
        {
            Load();
            StopCoroutine(LookForSpawner());

        }
        yield return new WaitForSeconds(0.2f);
    }


    public void OnNewGameButtonPressed()
    {
        loadSave = false;
    }

    public void OnLoadGameButtonPressed()
    {
        loadSave = true;
    }
}
