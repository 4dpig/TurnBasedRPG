using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    // 交互对象的名称
    public string interactiveObjectName;
    // 玩家与这个交互对象交互后，所显示的文本
    public ObjectText[] lines;
    
    private bool isPlayerInNPCArea;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInNPCArea && Input.GetButtonDown("Submit"))
        {
            DialogManager.instance.showDialog(lines, interactiveObjectName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInNPCArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInNPCArea = false;
        }
    }
}
