using Gpm.Ui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData
{
    public UserInventoryData UserInventoryData;
}

public class InventoryItemSlot : InfiniteScrollItem
{
    [SerializeField] private Image _gradeBg;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _levelTxt; 

    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        var slotData = scrollData as InventoryItemSlotData;
        _gradeBg.sprite = Resources.Load<Sprite>($"Textures/{ItemModel.GetGrade(slotData.UserInventoryData.item_id)}");
        _itemIcon.sprite = Resources.Load<Sprite>($"Textures/{ItemModel.GetIconPath(slotData.UserInventoryData.item_id)}");
        _levelTxt.text = $"Lv.{slotData.UserInventoryData.item_level}";
    }
}
