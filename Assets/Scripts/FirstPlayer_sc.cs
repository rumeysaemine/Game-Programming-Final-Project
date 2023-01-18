using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPlayer_sc : MonoBehaviour
{
    public float speed = 0f;
    int i = 0;
    
    public bool levelComplete = false;
    public bool gameOver = false;
    public Animator animator;

    private AudioSource audioSource;
  
    int isEnd = 1;
   
    int x_position=10;

    [SerializeField] private GameObject _platformPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
       speed = 0f;
       animator = GetComponent<Animator>();

       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelComplete)
        {
            StartCoroutine(SahneyiGec());

        }
        if(gameOver)
        {
            StartCoroutine(GameOverGec());
        }
    }

    void FixedUpdate()
    {
        if(transform.position.y < 1.4f)
        {

            gameOver = true;
            //animator.SetBool("kaybetme",true);
        }
        if(speed == 1)
        {
            animator.SetFloat("hareket", 0.4f);
           
        }
        else
        {
            animator.SetFloat("hareket",0);
            
            audioSource.Play();    //Yurume sesi
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            speed = 0f;
            GameObject final = GameObject.FindWithTag("Target").transform.parent.gameObject;
            GameObject platform = final.transform.parent.gameObject;

            //Debug.Log(platform.transform.position.x);
            transform.position = new Vector3(platform.transform.position.x,1.75f,0f);
            
            GameObject newBridge = platform.transform.GetChild(0).gameObject;
            
            newBridge.SetActive(true);
            
            Destroy(GameObject.FindWithTag("Target"));
            
            if(i<1)
            {
                newPlatform();
                i++;   
            }
            else
            {
                
                newBridge.SetActive(false);   //Kazanma durumu.Eger oyuncu dusmediyse.
                   
                animator.SetBool("kazanma",true); 
                levelComplete = true;
                isEnd--;
            }
            
        }   
    }

    void newPlatform() 
    {

        Vector3 position = new Vector3(x_position, 0, 0);
        x_position += 5;
 
        GameObject newFinal = Instantiate(_platformPrefab, position, Quaternion.identity); 
           
    }


    IEnumerator SahneyiGec()
    {
        yield return new WaitForSeconds(4.0f); 
        AsyncOperation asyncLoad = GoNextLevel();
        // Sahne yüklenmiş olana kadar bekle
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    AsyncOperation GoNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextLevel = 1 + scene.buildIndex;
        AsyncOperation asycnLoad = SceneManager.LoadSceneAsync(nextLevel);
        return asycnLoad;
    }

    IEnumerator GameOverGec()
    {
        yield return new WaitForSeconds(1.0f); // opsiyonel
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(3);
        // Sahne yüklenmiş olana kadar bekle
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
     
}

