using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PauseMenu : MonoBehaviour
{
    public GameObject optionsScreen,pauseScreen;
    public GameObject loadingScreen;
    public GameObject loadingIcon;
    public Text loadingText;

    public string MainMenuSceen;

    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            // actually pause the game
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            isPaused = false;

            // reset the screen freeze
            Time.timeScale = 1f;

        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        //  SceneManager.LoadScene(MainMenuSceen);
        // reset the screen freeze add here as mainmenu is also frozen
        //  Time.timeScale = 1f;
        Time.timeScale = 1f;
        StartCoroutine(LoadMain());
    }

    public IEnumerator LoadMain()
    {

        // activate the loading sceen
        loadingScreen.SetActive(true);
        // load sceen in background
             AsyncOperation asyncload = SceneManager.LoadSceneAsync(MainMenuSceen);
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
