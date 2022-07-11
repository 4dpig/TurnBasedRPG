using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    public string characterName;
    
    public int currentLevel = 1;
    public int maxLevel = 100;
    
    public int currentEXP;
    public int baseEXP = 1000; 
    public float incrementalFactor = 1.05f;
    private int[] EXPToNextLevel;
    
    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    
    public int strength;
    public int defence;
    
    public int weaponPower;
    public int armorPower;
    public string equippedWeaponName;
    public string equippedArmorName;
    
    public Sprite characterImage;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
         * 假如最高等级100级，需要记录99个经验值，数组只需要长度为99。
         * 但是现在把数组长度+1，这样的话，数组下标值与人物等级值的数字就一一对应了，不需要+1 -1之类的换算。
         * EXPToNextLevel[0]就是0级到1级需要的经验值，只作为一个占位格，不实际使用。
         * EXPToNextLevel[1]就是1级到2级需要的经验值。
         * EXPToNextLevel[2]就是2级到3级需要的经验值。
         */
        EXPToNextLevel = new int[maxLevel];
        EXPToNextLevel[1] = baseEXP;

        // 指数函数：exp(i) = base * radix^(i-1)
        for (int i = 2; i < maxLevel; i++)
        {
            EXPToNextLevel[i] = Mathf.FloorToInt(EXPToNextLevel[i - 1] * incrementalFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
