using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_sc : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _starPrefab;
    GameObject finalBridge;
    GameObject final;
    
    private AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(new Vector3(0,0,45 * 0.05f));
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource2.Play(); 
        Destroy(this.gameObject);            
    }
  
}
