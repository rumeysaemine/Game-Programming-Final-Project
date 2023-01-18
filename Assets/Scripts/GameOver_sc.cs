using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_sc : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SkipMainMenu()
    {
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
   

}
