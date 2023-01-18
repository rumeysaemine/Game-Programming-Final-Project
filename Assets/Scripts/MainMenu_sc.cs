using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{
   
    //UnityEngine.UI.Button button = GameObject.Find("continueButton").GetComponent<UnityEngine.UI.Button>();
    //int saved_level_name;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("saved_level");
        if (PlayerPrefs.HasKey("saved_level") == false)
        {
            GameObject continueButton = GameObject.FindGameObjectWithTag("continueButton");
            continueButton.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()   //New Game butonu tıklandığında
    {
        Time.timeScale = 1;
        StartCoroutine(newGame());
    }

    IEnumerator newGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        // Sahne yüklenmiş olana kadar bekle
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ContinueGame()   //Continue butonu tıklandığında
    {
        Time.timeScale = 1;
        
        if (PlayerPrefs.HasKey("saved_level") == true)
        {
            int saved_level_index = PlayerPrefs.GetInt("saved_level");
            //Debug.Log("Deneme:"+SceneManager.GetSceneByBuildIndex(saved_level_index).IsValid());
        
            SceneManager.LoadScene(saved_level_index);
        }

        // else
        // {
        //     Debug.Log("Saved game not found.");
        // }
    }

}
