using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    DragDropSystem DDS;
    [SerializeField] List<GameObject> Items;

    private void Start()
    {
        DDS = FindObjectOfType<DragDropSystem>();
    }

    public void OnSlot1Clicked()
    {
        DDS.PlacementItem = Instantiate(Items[0]);
    }
    public void OnSlot2Clicked()
    {
        DDS.PlacementItem = Instantiate(Items[1]);
    }
    public void OnSlot3Clicked()
    {
        DDS.PlacementItem = Instantiate(Items[2]);
    }
    public void OnSlot4Clicked()
    {
        DDS.PlacementItem = Instantiate(Items[3]);
    }
    public void OnSlot5Clicked()
    {
        DDS.PlacementItem = Instantiate(Items[4]);
    }

}
