using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    // 地图
    public Tilemap theMap;
    
    // camera所要跟随的目标的transform引用
    private Transform target;

    private float cameraHorizontalMin;
    private float cameraHorizontalMax;
    private float cameraVerticalMin;
    private float cameraVerticalMax;
    
    // Start is called before the first frame update
    private void Start()
    {
        // 目标设为player的transform
        target = PlayerController.theOnlyPlayerInstance.transform;
        
        // 获取camera的竖向视口大小的一半（即为Camera的Inspector里size的一半）
        float halfV = Camera.main.orthographicSize;
        // 获取camera的横向视口大小的一半，aspect为分辨率比例（比如16/9），halfV乘以aspcet即得到横向视口大小的一半
        float halfH = halfV * Camera.main.aspect;
        
        // 获取map一半的宽与高
        float halfMapWidth = theMap.size.x / 2;
        float halfMapHeight = theMap.size.y / 2;

        // 设置camera的坐标范围
        cameraHorizontalMin = -halfMapWidth + halfH;
        cameraHorizontalMax = -cameraHorizontalMin;
        cameraVerticalMin = -halfMapHeight + halfV;
        cameraVerticalMax = -cameraVerticalMin;
    }

    // LateUpdate is called once per frame after Update
    private void LateUpdate()
    {
        // 移动camera，但同时将camera的坐标控制在设置的范围之内
        float x = Mathf.Clamp(target.position.x, cameraHorizontalMin, cameraHorizontalMax);
        float y = Mathf.Clamp(target.position.y, cameraVerticalMin, cameraVerticalMax);
        
        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
}
