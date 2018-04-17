using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject panel;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
        }
	}

    public void ResumeGame()
    {
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
    }

}
