using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int playerScore;
    public static float fuelValue,
                        woodValue,
                        stoneValue;
    public static int playerHealthPoints;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        fuelValue = 50f;
        woodValue = 0f;
        stoneValue = 0f;
        playerHealthPoints = 100;
        scoreText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = playerScore.ToString();
        if(playerScore >= 250)
        {
            SceneManager.LoadScene("Map_Win");
        }
    }
}
