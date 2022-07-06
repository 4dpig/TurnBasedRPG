using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject UICanvasPrefab;

    // Awake is called before Start
    void Start()
    {
        if (PlayerController.instance == null)
        {
            // 复制prefab来创建一个player实例，并立即获取对应的playerController对象
            GameObject player = Instantiate(playerPrefab);
            PlayerController.instance = player.GetComponent<PlayerController>();
        }
        
        if (UICanvasController.instance == null)
        {
            // 复制prefab来创建一个uicanvas实例，并立即获取对应的uicanvas对象
            GameObject UICanvas = Instantiate(UICanvasPrefab);
            UICanvasController.instance = UICanvas.GetComponent<UICanvasController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
