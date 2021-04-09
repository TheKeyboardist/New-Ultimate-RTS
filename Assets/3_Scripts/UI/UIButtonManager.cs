/***********************************************************************;
* Project            : Final Line
*
* Author             : David Gasinec
* 
* Student Number     : 101187910
*
* Date created       : 20/11/20
*
* Description        : Load scenes with button press.
*
* Last modified      : 21/02/18
*
* Revision History   :
*
* Date        Author Ref    Revision (Date in YYYYMMDD format) 
* 21/02/04    David Gasinec        Created script. 
* 21/02/06    David Gasinec        Added further button funtionality.
*
*
|**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;

    private void Start()
    {
        
    }

    //Title Scene - yet to be implemented.


    /** Adds delay so the sound can play and isn't cut off. */
    private IEnumerator WaitForMainMenuStart()
    {
        yield return new WaitForSeconds(0.5f);
        //SceneManager.LoadScene("MenuScene");
    }

    /** Makes the button change scenes. */
    public void OnStartTitleButtonClicked()
    {
        StartCoroutine(WaitForMainMenuStart());
    }

    // Main menu //

    private IEnumerator WaitForSceneLoadPlayGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Map_Bohan");
    }

    public void OnButtonClickedPlay()
    {
        StartCoroutine(WaitForSceneLoadPlayGame());
    }

    // How to play//

    private IEnumerator WaitForHowToPlay()
    {
        yield return new WaitForSeconds(0.5f);
        //SceneManager.LoadScene("");
        Debug.Log("You have pressed how to play.");
    }

   public void OnHowToPlayButtonClicked()
    {
        StartCoroutine(WaitForHowToPlay());
    }

    // Settings //

    private IEnumerator WaitForSettings()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Map_Options");
    }

    public void OnSettingsButtonClicked()
    {
        StartCoroutine(WaitForSettings());
    }

    // Exit //

    private IEnumerator WaitForExit()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("You have pressed exit."); 

        // Note* this function will not work in the editor. 
        Application.Quit();
    }

    public void OnExitButtonClicked()
    {
        StartCoroutine(WaitForExit());
    }


    //Title//

    private IEnumerator WaitForStart()
    {
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Map_Menu");
    }

    public void OnStartButtonClicked()
    {
        StartCoroutine(WaitForStart());
    }



    //Game Over//

    private IEnumerator WaitForPlayAgain()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Map_Bohan");
        // Note* this function will not work in the editor. 
        Application.Quit();
    }

    public void OnStartOverButtonClicked()
    {
        StartCoroutine(WaitForPlayAgain());
    }

    // back to main
    private IEnumerator WaitForBackToMain()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("You have pressed back to main menu.");
        SceneManager.LoadScene("Map_Menu");
    }

    public void OnBackToMainButtonClicked()
    {
        StartCoroutine(WaitForBackToMain());
    }

    //Pause button on Game Screen
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false; 
    }

    public void OnPausedButtonPressed()
    {
        
        if(isPaused)
        {
            Resume();
            Debug.Log("Game unpaused button");
        }
        else
        {
            Pause();
            Debug.Log("Game Paused button");
        }

    }


    //Options
    private IEnumerator WaitForBackToMainOptions()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("You have pressed back to main menu.");
        SceneManager.LoadScene("Map_Menu");
    }

    public void OnBackToMainOptionsButtonClicked()
    {
        StartCoroutine(WaitForBackToMainOptions());
    }

}
