/***********************************************************************;
* Project            : Final Line
*
* Author             : David Gasinec
* 
* Student Number     : 101187910
*
* Date created       : 20/11/20
*
* Description        : Pause menu functionality.
*
* Last modified      : 21/02/04
*
* Revision History   :
*
* Date        Author Ref    Revision (Date in YYYYMMDD format) 
* 21/02/04    David Gasinec        Created script. 
*
*
|**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseScript : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenuPanel;
    
    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
                Debug.Log("pressed unpause escape key");
            }
            else if (isPaused)
            {
                Resume();
                Debug.Log("pressed pause escape key");
            }
        }

    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loaing menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map_menu");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
