using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed;
    public Animator animController;

    // 记录玩家所在的上一个scene
    public string thePreviousScene;
    
    // 单一玩家实例
    public static PlayerController theOnlyPlayerInstance;
    
    public const float PRECISION = 1e-6f;

    public static bool isNotZero(float number)
    {
        return Math.Abs(number) > PRECISION;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (theOnlyPlayerInstance == null)
        {
            theOnlyPlayerInstance = this;
            DontDestroyOnLoad(theOnlyPlayerInstance.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 获取用户输入：
         * Horizontal：
            * 向右走（D键或方向右键），返回1；
            * 向左走（A键或方向左键），返回-1；
            * 无操作，返回0；
         * Vertical：
            * 向上走（W键或方向上键），返回1；
            * 向下走（S键或方向下键），返回-1；
            * 无操作，返回0；
         */
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        // 以用户输入为基准，设置player速度
        body.velocity = new Vector2(moveX, moveY) * moveSpeed;
        
        // 给 控制人物动画的参数 赋值
        animController.SetFloat("moveX", moveX);
        animController.SetFloat("moveY", moveY);
        
        if(isNotZero(moveX) || isNotZero(moveY))
        {
            animController.SetFloat("lastMoveX", moveX);
            animController.SetFloat("lastMoveY", moveY);
        }
    }
}
