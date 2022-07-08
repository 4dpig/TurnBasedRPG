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
    
    // Start is called before the first frame update
    void Start()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string s in dialogLines)
        {
            sb.AppendLine(s);
        }

        dialogText.text = sb.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
