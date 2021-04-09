using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileInfantryBehaviour : MonoBehaviour
{
    GameObject targetRef;
    GameObject[] obstacleTargets;
    Transform targetTransform;
    Vector3 currDir;
    [SerializeField] float moveSpeed = 15.0f;


    public NavMeshAgent agent;

    void Start()
    {
        targetRef = GameObject.FindGameObjectWithTag("Base");
        obstacleTargets = GameObject.FindGameObjectsWithTag("");

        targetTransform = targetRef.GetComponent<Transform>();


        agent.SetDestination(targetTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        currDir = targetTransform.position - transform.position;
        float distance = currDir.magnitude;
        Vector3 normDir = currDir / distance;
        transform.rotation = Quaternion.LookRotation(normDir);

    }

    private void FixedUpdate()
    {
        //moveCharacter(currDir);

    }


    void moveCharacter(Vector3 direction)
    {
        transform.position += currDir.normalized * moveSpeed * Time.deltaTime;
    }
}
