using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.theOnlyPlayerInstance == null)
        {
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
