using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasController : MonoBehaviour
{
    public static UICanvasController instance;
    
    public Image fadeImage;
    // 切换场景时，渐进或淡出所花费的时间
    public float fadeTime = 1f;

    private bool shouldFadeToBlack = false;
    private bool shouldFadeFromBlack = false;
 
    // Start is called before the first frame update
    void Start()
    {
        /*
       * 第一种情况：从主Scene启动的游戏
       * 第二种情况：从其他的Scene启动的游戏（作为测试用）
       * 第三种情况：从其他的Scene启动，当返回到主Scene时，销毁新产生的那个gameobject
       */
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else if(instance == this)
        {
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeImage.color = new Color(
                0f,
                0f,
                0f,
                Mathf.MoveTowards(fadeImage.color.a, 1f, Time.deltaTime / fadeTime)
            );

            if (FloatTools.equals(fadeImage.color.a, 1f))
            {
                shouldFadeToBlack = false;
            }
        }
        else if (shouldFadeFromBlack)
        {
            fadeImage.color = new Color(
                0f,
                0f,
                0f,
                Mathf.MoveTowards(fadeImage.color.a, 0f, Time.deltaTime / fadeTime)
            );

            if (FloatTools.equals(fadeImage.color.a, 0f))
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void fadeToBlack()
    {
        shouldFadeToBlack = true;
    }
    
    public void fadeFromBlack()
    {
        shouldFadeFromBlack = true;
    }
}
