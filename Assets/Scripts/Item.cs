using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public bool isItem, isWeapon, isArmour;
    public bool affectHP, affectMP, affectAtk;

    public string itemName, description, value;
    public string amoutToChange;

    public int weaponDamage, armorDefence;

    public Sprite itemSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
