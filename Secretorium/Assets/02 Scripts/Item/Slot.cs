using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;   //획득한 아이템
    public int itemCount;   //획득한 아이템의 갯수
    public Image ItemImage; //아이템의 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    //아이템 이미지의 투명도 조절
    public void SetColor(float _alpha)
    {
        Color color = ItemImage.color;
        color.a = _alpha;
        ItemImage.color = color;
    }

    //인벤토리에 새로운 아이템 슬롯추가
    public void addItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        ItemImage.sprite = item.itemImage;

        if(item.itemType != Item.ItemType.ECT)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        SetColor(1);
    }
    
    //해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    //해당 슬롯 하나 삭제
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        ItemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
}
