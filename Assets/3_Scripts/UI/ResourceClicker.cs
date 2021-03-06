using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceClicker : MonoBehaviour
{

    public AudioSource resourceSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);

                    if(hit.transform.gameObject.name == "Resource")
                    {
                        ResourceCounter.resourceNumber += 100;
                        resourceSound.Play();
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
}
