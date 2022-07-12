using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharacterStats[] characterStats;
    
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
        
    }
}
