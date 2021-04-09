using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    [SerializeField] Material GoodMat;
    [SerializeField] Material BadMat;
    [SerializeField] bool IsValid = true;
    public bool IsPlacedDown = false;

    void Awake()
    {
        if (IsPlacedDown)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonUp(0))
        {
            if(!IsValid && !IsPlacedDown)
            {
                Destroy(transform.parent.gameObject);
            }
            else if (IsValid && !IsPlacedDown)
            {
                IsPlacedDown = true;
                transform.parent.GetComponent<S_ItemInfo>().BuyItem();
            }
            if(IsPlacedDown)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "RangeVisualizer")
        {
            IsValid = false;
            GetComponent<MeshRenderer>().material = BadMat;

            if(IsPlacedDown)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "RangeVisualizer")
        {
            IsValid = true;
            GetComponent<MeshRenderer>().material = GoodMat;

            if (IsPlacedDown)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
