using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
  public string charName;
  public int playerLevel = 1;
  public int currentEXP;
  public int[] expToNextLevel;
  public int maxLevel = 50;
  public int baseEXP = 1000;


  public int currentHP;
  public int maxHP = 100;
  public int currentMP;
  public int maxMP = 10;
  public int strenght;
  public int defence;
  public int weaponDamage;
  public int armorDefence;
  public string equippedWeapon;
  public string equippedArmor;
  public Sprite charImage;
  void Start()
  {

      currentHP = maxHP;


    expToNextLevel = new int[maxLevel];
    expToNextLevel[1] = baseEXP;

    for (int i = 2; i < expToNextLevel.Length; i++)
    {
      expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
    }
  }


  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      AddExp(10000);
    }
  }

  public void AddExp(int expToAdd)
  {
    currentEXP += expToAdd;

    if (playerLevel < maxLevel)
    {
      if (currentEXP > expToNextLevel[playerLevel])
      {
        currentEXP -= expToNextLevel[playerLevel];

        playerLevel++;

        updateStats();
      }
    }
    else
    {
        currentEXP = 0;
    }
  }

  public void updateStats()
  {
    strenght = Mathf.FloorToInt((strenght + playerLevel) * 1.05f);
    defence = Mathf.FloorToInt((defence + playerLevel) * 1.03f);
    maxHP = Mathf.FloorToInt((maxHP + playerLevel) * 1.08f);
    maxMP = Mathf.FloorToInt((maxMP + playerLevel) * 1.03f);
  }
}
