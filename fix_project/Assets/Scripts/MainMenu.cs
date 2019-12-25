using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string firstlevel;
    public GameObject optionsScreen, CreditScreen, GameStartScreen, LoadGameScreen, NewGameScreen;
    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame ()
    {
        // SceneManager.LoadScene(firstlevel);

        StartCoroutine(LoadStart());
    }

    public void OpenOptions ()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions ()
    {
        optionsScreen.SetActive(false);
    }

    public void OpenGameStart()
    {
        GameStartScreen.SetActive(true);
    }

    public void CloseGameStart()
    {
        GameStartScreen.SetActive(false);
    }


    public void OpenGameClose()
    {
        GameStartScreen.SetActive(false);
    }

    public void OpenLoad()
    {

        LoadGameScreen.SetActive(true);
    }

    public void CloseLoad()
    {
        LoadGameScreen.SetActive(false);
    }


    public void OpenNewGame()
    {

        NewGameScreen.SetActive(true);
    }

    public void CloseNewGame()
    {
        NewGameScreen.SetActive(false);
    }
    // Adding in code for Credits screen open and close

    public void OpenCreditsOptions()
    {
        CreditScreen.SetActive(true);
    }

    public void CloseCreditsOptions()
    {
        CreditScreen.SetActive(false);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public IEnumerator LoadStart()
    {

        // activate the loading sceen
        loadingScreen.SetActive(true);
        // load sceen in background
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(firstlevel);
        // Wait for user before continue
        asyncload.allowSceneActivation = false;

        while (!asyncload.isDone)
        {
            if (asyncload.progress >= .9f)
            {
                loadingText.text = "Press any key to continue....";
                // couild not get icon to turn off          
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncload.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }


            }
            yield return null;
        }
    }
}
