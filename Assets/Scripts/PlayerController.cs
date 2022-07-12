using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 玩家的坐标范围
    private float playerHorizontalMin;
    private float playerHorizontalMax;
    private float playerVerticalMin;
    private float playerVerticalMax;

    public Rigidbody2D body;
    public float moveSpeed;
    public Animator animController;

    // 记录玩家所在的上一个scene
    public string thePreviousScene;
    
    // 控制玩家能否移动
    public bool canPlayerMove = true;
    
    // 单一玩家实例
    public static PlayerController instance;
    

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
        if (canPlayerMove)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
        
            // 以用户输入为基准，设置player速度
            body.velocity = new Vector2(moveX, moveY) * moveSpeed;
        
            // 将player坐标控制在范围之内
            float x = Mathf.Clamp(this.transform.position.x, playerHorizontalMin, playerHorizontalMax);
            float y = Mathf.Clamp(this.transform.position.y, playerVerticalMin, playerVerticalMax);
            this.transform.position = new Vector3(x, y, this.transform.position.z);
        
            // 给 控制人物动画的参数 赋值
            animController.SetFloat("moveX", moveX);
            animController.SetFloat("moveY", moveY);
        
            if(FloatTools.IsNotZero(moveX) || FloatTools.IsNotZero(moveY))
            {
                animController.SetFloat("lastMoveX", moveX);
                animController.SetFloat("lastMoveY", moveY);
            }
        }
        
    }

    // 根据当前地图边界坐标来设置玩家的坐标范围
    public void SetPlayerBounds(Vector3 leftBottom, Vector3 rightTop)
    {
        // 获取playersize
        Vector3 playerSize = this.gameObject.GetComponent<Renderer>().bounds.size;
        
        playerHorizontalMax = rightTop.x - playerSize.x / 2;
        playerHorizontalMin = leftBottom.x + playerSize.x / 2;
        playerVerticalMax = rightTop.y - playerSize.y / 3;
        playerVerticalMin = leftBottom.y + playerSize.y / 3;
    }
}
