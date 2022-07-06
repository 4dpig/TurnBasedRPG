using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class SceneLoader : MonoBehaviour
{
    public string sceneToExit;
    public string sceneToLoad;

    private float fadeTimeLeft;
    private bool isLoading = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoading)
        {
            fadeTimeLeft -= Time.deltaTime;
        
            if (fadeTimeLeft <= 0f)
            {
                isLoading = false;
                // 加载新的scene
                SceneManager.LoadScene(sceneToLoad);
                // 记录玩家所在的上一个scene
                PlayerController.instance.thePreviousScene = sceneToExit;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 开始渐变
            isLoading = true;
            fadeTimeLeft = UICanvasController.instance.fadeTime;
            UICanvasController.instance.fadeToBlack();
        }
    }
}
