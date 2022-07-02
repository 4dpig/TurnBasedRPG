using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePointController : MonoBehaviour
{
    // 与入口处相对应的那个Scene
    public string sceneCorrespondingToTheEntrance;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
         * 如果 与入口处相对应的那个Scene 等于 玩家所在的上一个Scene
         * 那么就把玩家的位置设为入口object所在的位置。
         */
        if (sceneCorrespondingToTheEntrance == PlayerController.theOnlyPlayerInstance.thePreviousScene)
        {
            PlayerController.theOnlyPlayerInstance.transform.position = this.transform.position;
        }
        // dsf
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}