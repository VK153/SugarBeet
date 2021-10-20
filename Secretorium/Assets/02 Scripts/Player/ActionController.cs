using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionController : MonoBehaviour
{
    private ItemInventory theInventory;
    public Slot[] slots;

    public int ChaserTiketNum;

    public bool TiketCoolTime = false;
    public bool HasActiveItem = false;

    public bool eat = false;
    public bool getItem = false;

    Player pl;

    private void Start()
    {
        theInventory = GameObject.Find("InventoryUI").GetComponent<ItemInventory>();
        slots = theInventory.slots;
        pl = GetComponent<Player>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item")&& eat == true)
        {
            getItem = true;
                theInventory.AcquireItem(collision.transform.GetComponent<ItemPickUp>().item);
                Destroy(collision.gameObject);
            return;
        }
        else if(collision.CompareTag("Item")&& Input.GetKeyDown(KeyCode.E))
        {
            getItem = false;
            if (collision.transform.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Active)
            {
                pl.scrap += 6;
            }
            Destroy(collision.gameObject);
        }
    }


    void Update()
    {
        //Debug.Log(eat);
        UseItem();
        if (Input.GetKeyDown(KeyCode.F))
        {
            eat = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            eat = false;
        }
    }
    public void UseItem()
    {
        if (TiketCoolTime == false && HasActiveItem == true) 
        {
            slots[1].SetColor(1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (theInventory.slots[1].item != null)
            {
                ItemList(slots[1].item);
                //slots[0].SetSlotCount(-1);
                if(slots[1].item.itemName == ("ChaserTiket"))
                {
                    HasActiveItem = true;
                    slots[1].SetColor(0.3f);
                    //ChaserTiketNum = 1;
                }
                else if(slots[1].item.itemName == ("InfectSpore"))
                {
                    HasActiveItem = true;
                    int i = Random.Range(0, 99);
                    if(i > 30)
                    {
                        pl.maxHp -= pl.maxHp * 0.05f;
                    }
                    GetComponentInChildren<WeaponFire>().gDmg = true;
                    slots[1].SetColor(0.3f);
                }
            }
        }
    }

    public void ItemList(Item _item)
    {
        if (_item.itemName == ("ChaserTiket") && TiketCoolTime == false)
        {
            GetComponent<Player>().aF = 10;
            GetComponent<Player>().aFCoolTime = 20;
            TiketCoolTime = true;
        }
        else if (_item.itemName == ("InfectSpore") && TiketCoolTime == false)
        {
            GetComponent<Player>().aFCoolTime = 20;
            TiketCoolTime = true;
        }
    }
}
