using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // camera所要跟随的目标的transform引用
    public Transform target;
    
    // Start is called before the first frame update
    private void Start()
    {
        // 目标设为player的transform
        target = PlayerController.theOnlyPlayerInstance.transform;
    }

    // LateUpdate is called once per frame after Update
    private void LateUpdate()
    {
        this.transform.position = new Vector3(
            target.position.x,
            target.position.y,
            this.transform.position.z
        );
    }
}
