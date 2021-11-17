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

    public float stopTime = 0;
    public bool stTime = false;


    Player pl;
    Holster hl;
    GameManager gm;

    private void Start()
    {
        theInventory = GameObject.Find("InventoryUI").GetComponent<ItemInventory>();
        slots = theInventory.slots;
        pl = GameObject.Find("Player").GetComponent<Player>();
        hl = GameObject.Find("Player").GetComponentInChildren<Holster>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item")&& Input.GetKeyDown(KeyCode.F))
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
        if(stTime == true)
        {
            stopTime -= Time.deltaTime;
            if(stopTime <= 0)
            {
                stTime = false;
                gm.pause = false;
            }
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
                else if(slots[1].item.itemName == ("HappyGrenade"))
                {
                    HasActiveItem = false;
                    pl.HG = 1;
                    pl.isAvoid = true;
                    pl.gameObject.GetComponentInChildren<WeaponFire>().canSoot = true;
                    slots[1].SetSlotCount(-1);
                }
                else if(slots[1].item.itemName == ("InvisiblePotion"))
                {
                    HasActiveItem = true;
                    hl.invisibleTime = 4;
                    slots[1].SetColor(0.3f);
                }
                else if(slots[1].item.itemName == ("TimeStop"))
                {
                    HasActiveItem = false;
                    slots[1].SetSlotCount(-1);
                    gm.pause = true;
                    stopTime = 0.05f;
                    stTime = true;
                    Debug.Log("sdfaf");
                }
            }
        }
    }

    public void ItemList(Item _item)
    {
        if (_item.itemName == ("ChaserTiket") && TiketCoolTime == false)
        {
            GameObject.Find("Player").GetComponent<Player>().aF = 10;
            GameObject.Find("Player").GetComponent<Player>().aFCoolTime = 20;
            TiketCoolTime = true;
        }
        else if (_item.itemName == ("InfectSpore") && TiketCoolTime == false)
        {
            GameObject.Find("Player").GetComponent<Player>().aFCoolTime = 20;
            TiketCoolTime = true;
        }
        else if (_item.itemName  == ("InvisiblePotion")&&TiketCoolTime == false)
        {
            GameObject.Find("Player").GetComponent<Player>().aFCoolTime = 10;
            TiketCoolTime = true;
        }
    }

}
