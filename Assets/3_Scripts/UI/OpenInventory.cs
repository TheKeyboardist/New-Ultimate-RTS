using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryPanel;

    public void OpenPanel()
    {
        if (inventoryPanel != null)
        {
            Animator inventoryAnim = inventoryPanel.GetComponent<Animator>();
            
            if(inventoryAnim != null)
            {
                bool isOpen = inventoryAnim.GetBool("Open");
                inventoryAnim.SetBool("Open", !isOpen);
            }
        }
    }
}
