using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInventory : MonoBehaviour
{
    public static bool inventoryActivated = false;  //인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막음

    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    public Slot[] slots;

    void Start()
    {
        //go_SlotsParent = GetComponentInChildren<Slot>().gameObject;
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        
    }
    public void AcquireItem(Item _item, int _count=1)
    {
        if (Item.ItemType.Passive == _item.itemType)
        {
            for (int i = 2; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
            for (int i = 2; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].addItem(_item, _count);
                    return;
                }
            }
        }
        if(Item.ItemType.Active == _item.itemType)
        {
            if(slots[1].item != null)
            {
                slots[1].SetSlotCount(-1);
                slots[1].addItem(_item, _count);
            }
            else if(slots[0].item == null)
            {
                slots[1].addItem(_item, _count);
            }
        }
        //for (int i = 2; i < slots.Length; i++)
        //{
        //    if (slots[i].item == null)
        //    {
        //        slots[i].addItem(_item, _count);
        //        return;
        //    }
        //}
    }


    public void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(slots[1].item != null)
            {
                slots[1].item = null;
                return;
            }
        }
    }
}
