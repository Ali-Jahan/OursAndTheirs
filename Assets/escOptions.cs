using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escOptions : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseScreen;
    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            if (Input.GetKey(KeyCode.Escape) && !paused)
            {
                print("pause");
                pause();
            }
        }
        

        // if (Input.GetKey(KeyCode.Escape) && paused)
        // {
        //     print("unpause");
        //     unpause();
        // }
    }

    public void pause()
    {
        pauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    public void unpause()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    
    public void loadLevelm3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level-3");
    }
    
    public void loadLevelm2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level-2");
    }
    
    public void loadLevelm1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level-1");
    }
    
    public void loadLevel0()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level0");
    }
    
    public void loadLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level1");
    }
    
    public void loadLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level2");
    }
    
    public void loadLevel4()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level4");
    }

    public void quit()
    {
        Application.Quit();
    }
}
