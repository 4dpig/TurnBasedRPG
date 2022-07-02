using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToExit;
    public string sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 加载新的scene
            SceneManager.LoadScene(sceneToLoad);
            // 记录玩家所在的上一个scene
            PlayerController.theOnlyPlayerInstance.thePreviousScene = sceneToExit;
        }
    }
}
