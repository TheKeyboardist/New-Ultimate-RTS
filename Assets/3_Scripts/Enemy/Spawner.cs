using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    [Header("Characters")]
    public GameObject character;

    [Header("Targets")]
    public string targetTag;

    [SerializeField]
    public float radius = 40.0f;
    public float delay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(WaitAndSpawn(delay)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator WaitAndSpawn(float time)
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            SpawnCharacterWithinRadius(character);
        }


    }


    void SpawnCharacterWithinRadius(GameObject character) //spawns a "character" within random position of a circle with "radius"
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        Instantiate(character, RandPosInCircle(target.gameObject.transform.position, radius), Quaternion.identity);
    }


    Vector3 RandPosInCircle(Vector3 target, float radius)//pick a location around "target" in a random position of a circle with "radius"
    {
        Vector3 returnVal = new Vector3();
        var angle = Random.value * 360;
        
        returnVal.x = target.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        returnVal.z = target.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        returnVal.y = target.y;

        return returnVal;
    }

}
