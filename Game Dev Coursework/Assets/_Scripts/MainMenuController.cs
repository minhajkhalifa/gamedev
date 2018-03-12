using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public AudioSource audio;

    public void OnMouseEnter()
    {
        audio.Play();
    }

    public void ButtonHandlerPlay()
    {
        SceneManager.LoadSceneAsync(Globals.PLAYER_TYPE_SCENE);
    }

    public void ButtonHandlerHelp()
    {
        SceneManager.LoadSceneAsync(Globals.HELP_SCENE);
    }

    public void ButtonHandlerSinglePlayer()
    {
        SceneManager.LoadSceneAsync(Globals.CAR_SELECTION_SCENE);
    }

    public void ButtonHandlerMultiPlayer()
    {
        //TODO;
    }

    public void ButtonHandlerExit()
    {
        Debug.Log("Application has quit");
        Application.Quit();
    }
}
