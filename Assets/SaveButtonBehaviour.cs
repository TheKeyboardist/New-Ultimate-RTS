using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonBehaviour : MonoBehaviour
{
    public void  OnSaveButtonPressed()
    {
        GameObject snlManager = GameObject.Find("SNLManager");
        SNLManager managerScript = snlManager.GetComponent<SNLManager>();
        managerScript.Save();
    }
}
