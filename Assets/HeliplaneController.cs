using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeliplaneController : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 position;

    public bool playerDefenceBroken;





    bool canMove;
    float speed;

    void Awake()
    {
        canMove = true;
        playerDefenceBroken = false;
        speed = 0.01f;

        position = new Vector3();
        GameObject startPositionGO = GameObject.Find("StartPosition");
        position = startPositionGO.transform.position;
        GameObject playerBase = GameObject.Find("MidPoint"); ;
        
        targetPosition = playerBase.transform.position;
    }


    void Start()
    {
        //start coroutine or smth.
    }

    void Update()
    {
        LookAtTarget();
        Move();

        if (Mathf.Abs(targetPosition.x - transform.position.x) <= 10.0f && Mathf.Abs(targetPosition.z - transform.position.z) <= 10.0f && IsPlayerDefenceBroken())
        {
            SceneManager.LoadScene("Map_Gameover");
        }
    }

    private void Move()
    {
        CheckMidPoint();
        targetPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
    }

    private void LookAtTarget()
    {
        targetPosition.y = transform.position.y;
        Vector3 relativePos = targetPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }



    void CheckMidPoint()
    {
        if(Mathf.Abs(targetPosition.x - transform.position.x) <= 10.0f && Mathf.Abs(targetPosition.z - transform.position.z) <= 10.0f)
        {
            canMove = false;
            if(IsPlayerDefenceBroken()) 
            {
                canMove = true;
                targetPosition = GameObject.Find("EndPosition").transform.position;
                targetPosition.y = transform.position.y;
            }
        }
    }

    bool IsPlayerDefenceBroken()
    {
        GameObject[] allDefense = GameObject.FindGameObjectsWithTag("Base");
        if (allDefense.Length < 1)
        {
            return true;
        }
        else return false;
    }



    
}
