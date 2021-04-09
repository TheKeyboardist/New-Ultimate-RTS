using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Quests : MonoBehaviour
{
    public static int enemyCount, placedTurrets;
    public static bool killedBoss, playedEnemies, playedBoss, playedTurrets,
        buildNTurrets;
    public Text taskDisplay;

    string task;
    bool kill100Enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        placedTurrets = 0;
        taskDisplay = GetComponent<Text>();
        task = "Default";
        kill100Enemies = false;
        buildNTurrets = false;
        killedBoss = false;
        playedEnemies = false;
        playedBoss = false;
        playedTurrets = false;
    }

    void Update()
    {
        if(enemyCount >= 50 && playedEnemies == false)
        {
            task = "Killed 50 enemies!";
            playedEnemies = true; 
        }
        if (killedBoss == true && playedBoss == false)
        {
            task = "You killed a Boss!";
            playedBoss = true;
        }
        if (placedTurrets >= 10 && playedTurrets == false)
        {
            task = "You placed 10 turrrets!";
            buildNTurrets = true;
            playedTurrets = true;
        }
        


        taskDisplay.text = task;
    }
}
