using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    public static int resourceNumber = 1000;
    public Text resources;

    private void Start()
    {
        resources = GetComponent<Text>();
    }

    private void Update()
    {
        resources.text = "" + resourceNumber;
    }
}
