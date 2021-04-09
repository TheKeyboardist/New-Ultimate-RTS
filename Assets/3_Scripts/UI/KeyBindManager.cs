using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindManager : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    private GameObject currentKey;
    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(255, 12, 0, 255);
    public Text up, down, left, right;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keys["Up"]))
        {
            Debug.Log("up");
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            Debug.Log("down");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("right");
        }

    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
}
