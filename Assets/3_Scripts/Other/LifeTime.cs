using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] float lifeTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LifeOver", lifeTime);
    }

    void LifeOver()
    {
        Destroy(gameObject);
    }
}
