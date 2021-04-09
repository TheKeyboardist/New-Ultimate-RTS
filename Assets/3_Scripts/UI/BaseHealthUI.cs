using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthUI : MonoBehaviour
{
    public S_MainBasic MainBasic;
    public Text HealthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = MainBasic.Health.ToString();
    }
}
