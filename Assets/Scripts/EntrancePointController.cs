using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntrancePointController : MonoBehaviour
{
    // 与入口处相对应的那个Scene
    public string sceneCorrespondingToTheEntrance;

    private float fadeTimeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
         * 如果 与入口处相对应的那个Scene 等于 玩家所在的上一个Scene
         * 那么将玩家的位置设为入口位置
         * 并进行渐变
         */
        if (sceneCorrespondingToTheEntrance == PlayerController.instance.thePreviousScene)
        {
            PlayerController.instance.transform.position = this.transform.position;
            UICanvasController.instance.fadeFromBlack();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}