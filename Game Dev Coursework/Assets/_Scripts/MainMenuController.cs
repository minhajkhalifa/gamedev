using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void ButtonHandlerPlay()
    {
        SceneManager.LoadSceneAsync(Globals.GAME_SCENE);
    }

    public void ButtonHandlerHelp()
    {
        SceneManager.LoadSceneAsync(Globals.HELP_SCENE);
    }

    public void ButtonHandlerExit()
    {
        Debug.Log("Application has quit");
        Application.Quit();
    }
}
