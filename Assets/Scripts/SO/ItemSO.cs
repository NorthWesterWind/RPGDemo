using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Itemtype
{
    Weapon,
    Consumable
}
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int id;
    public string itemname;
    public E_Itemtype itemtype;
    public string info;
    public List<Property> propertyList;
    public Sprite icon;
    public GameObject prefab;
}

public enum E_PropertyType
{
    HpValue,
    EneryValue,
    MentalValue,
    SpeedValue,
    AttackValue
}
[Serializable]
public class Property
{
    public E_PropertyType propertyType;
    public int value;
    public Property()
    {

    }
    public Property(E_PropertyType propertyType, int value)
    {
        this.propertyType = propertyType;
        this.value = value;
    }   
}
