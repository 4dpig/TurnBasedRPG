using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject nameBox;
    
    public Text dialogText;
    public Text nameText;
    
    public string interactiveObjectName;
    public ObjectText[] lines;

    public int currentLine;

    public static DialogManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (currentLine < lines.Length)
                {
                    showOneLine();
                }
                else
                {
                    dialogBox.SetActive(false);
                    // 恢复玩家移动
                    PlayerController.instance.canPlayerMove = true;
                }
            }
        }
    }

    public void showDialog(ObjectText[] newLines, string newInteractiveObjectName)
    {
        // 不让玩家移动
        PlayerController.instance.canPlayerMove = false;
        
        // 初始化
        lines = newLines;
        interactiveObjectName = newInteractiveObjectName;
        currentLine = 0;
        dialogBox.SetActive(true);
        
        // 显示第一行
        showOneLine();
    }

    private void showOneLine()
    {
        // 显示名字
        if (lines[currentLine].isPlayer)
        {
            nameText.text = "Player";
        }
        else
        {
            nameText.text = interactiveObjectName;
        }
        
        // 显示文本
        dialogText.text = lines[currentLine].text;
        
        currentLine++;
    }
}
