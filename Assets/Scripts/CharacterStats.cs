using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    public string characterName;
    
    public int currentLevel = 1;
    public int maxLevel = 100;
    
    public int currentEXP;
    public int baseEXP = 1000; 
    public float EXPIncrementalFactor = 1.05f;
    private int[] EXPToNextLevel;
    
    public int currentHP = 100;
    public int maxHP = 100;
    public int currentMP = 30;
    public int maxMP = 30;
    
    public int strength = 10;
    public int defence = 5;
    
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
         * 但是现在把数组长度+1，目的：
         * 数组的第0个位置不使用，仅作为一个占位格，这样数组下标值与人物等级值的数字就一一对应了。
         */
        
        EXPToNextLevel = new int[maxLevel];
        EXPToNextLevel[1] = baseEXP;

        // 指数函数：exp(i) = base * radix^(i-1)
        for (int i = 2; i < maxLevel; i++)
        {
            EXPToNextLevel[i] = Mathf.FloorToInt(EXPToNextLevel[i - 1] * EXPIncrementalFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddEXP(500);
            Debug.Log($"level:{currentLevel}\texp:{currentEXP}");
        }
    }

    public void AddEXP(int expToAdd)
    {
        if (currentLevel < maxLevel)
        {
            currentEXP += expToAdd;
            int expRequired = EXPToNextLevel[currentLevel];
        
            if (currentEXP >= expRequired)
            {
                // currentEXP减去升级所用的经验值。如果是从满级前一级升到满级，currentEXP直接设为0
                if (currentLevel != maxLevel - 1)
                {
                    currentEXP -= expRequired;
                }
                else
                {
                    currentEXP = 0;
                }
                
                // 增加HP
                maxHP += (currentLevel / 10 + 1) * 10;
                currentHP = maxHP;
                
                // 增加MP
                maxMP += (currentLevel / 10 + 1) * 2;
                currentMP = maxMP;
                
                // 增加strength和defense
                strength++;
                defence++;
                
                // 升级
                currentLevel++;
            }
        }
    }
    
}
