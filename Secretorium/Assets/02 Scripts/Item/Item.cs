using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "New Item/Item")]
public class Item : ScriptableObject
{
    public enum ItemType    //아이템 유형
    {
        Weapon,
        Active,
        Passive,
        ECT
    }

    public string itemName; //아이템의 이름
    public ItemType itemType;   //아이템 유형
    public Sprite itemImage;    //아이템 이미지(인벤토리 안에 띄울)
    public GameObject itemPreFab;   //아이템의 프리팹(아이템 생성시 프리팹으로 찍어냄)

    public string weaponType;   //무기유형
}
