using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_sc : MonoBehaviour
{

    Canvas ana_kanvas;
    public bool pause = false;
    private bool x = false;

    
    // Start is called before the first frame update
    void Start()
    {
        ana_kanvas = GameObject.FindObjectOfType<Canvas>();
        ana_kanvas.enabled = false;     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Cancel") != 0)
        {   
            if(x == false)
            {
                ana_kanvas.enabled = !ana_kanvas.enabled;
                if (pause)
                {
                    Time.timeScale = 1;
                    pause = false;
                }
                else
                {
                    Time.timeScale = 0;
                    pause = true;
                }
                x = true;
            }      
        }
        
        if(Input.GetAxisRaw("Cancel") == 0)
        {
            x = false;
        } 
    }
    public void ResumeGame()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
        ana_kanvas.enabled = false;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void SkipMainMenu()
    {
        SaveGame();     //Main Menuye gecis sırasında oynanan bolum kaydedilir.
        StartCoroutine(MenuyeGec());
    }

    IEnumerator MenuyeGec()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        // Sahne yüklenmiş olana kadar bekle
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SaveGame()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("saved_level",SceneManager.GetActiveScene().buildIndex);
    }
}
