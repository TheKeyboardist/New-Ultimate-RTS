using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour
{
    private static GameRuleManager instance;

    [Header("Global")]
    public int Time_Min;
    public int Time_Sec;
    public string CurrentLvl;

    [Header("Current Game Status")]
    public uint CurrentDay;
    public uint Score;
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Turrets = new List<GameObject>();

    private void Awake()
    {
        if (instance)   { Destroy(gameObject); }
        else            { instance = this;     }
    }
}
