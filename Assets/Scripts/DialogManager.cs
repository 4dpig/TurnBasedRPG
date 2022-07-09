using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject nameBox;
    
    public Text dialogText;
    public Text nameText;

    public string[] dialogLines;

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
                currentLine++;
                
                if (currentLine < dialogLines.Length)
                {
                    dialogText.text = dialogLines[currentLine];
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

    public void showDialog(string[] newLines)
    {
        // 不让玩家移动
        PlayerController.instance.canPlayerMove = false;
        
        dialogLines = newLines;
        currentLine = 0;

        dialogBox.SetActive(true);
        dialogText.text = dialogLines[currentLine];
    }
}
