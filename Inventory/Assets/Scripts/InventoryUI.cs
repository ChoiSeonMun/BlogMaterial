using Gpm.Ui;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;
    [SerializeField] private TextMeshProUGUI _sortBtnTxt;
    [SerializeField] private TextMeshProUGUI _filterBtnTxt;

    private enum FilterType
    {
        All,
        Weapon,
        Shield,
        ChestArmor,
        Gloves,
        Boots,
        Accessery,
        Max
    }
    private FilterType _filterType = FilterType.All;

    private enum SortType
    {
        Grade,
        Level,
        Max
    }
    private SortType _sortType = SortType.Grade;

    private List<UserInventoryData> _userItems = new();
    private void Awake()
    {
        SetUserData();
    }

    private void SetUserData()
    {
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 11001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 11002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 21001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 21002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 31001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 31002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 41001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 41002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 51001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 51002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 61001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 61002 });

        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 14001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 14002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 24001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 24002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 34001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 34002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 44001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 44002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 54001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 54002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 64001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 64002 });

        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 12001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 12002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 22001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 22002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 32001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 32002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 42001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 42002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 52001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 52002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 62001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 62002 });

        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 12001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 12002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 22001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 22002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 32001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 32002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 42001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 42002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 52001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 52002 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 62001 });
        _userItems.Add(new UserInventoryData() { serial_number = CreateSerialNumber(), item_level = UnityEngine.Random.Range(10, 20), item_id = 62002 });

        
    }

    private long CreateSerialNumber()
    {
        return long.Parse($"{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}{UnityEngine.Random.Range(0, 10000):D4}");
    }

    void Start()
    {
        Refresh();
    }

    public void OnClickFilterBtn()
    {
        int filterTypeNumber = (int)_filterType;
        int newFilterTypeNumber = (filterTypeNumber + 1) % (int)FilterType.Max;
        _filterType = (FilterType)newFilterTypeNumber;

        Refresh();
    }

    public void OnClickSortBtn()
    {
        int sortTypeNumber = (int)_sortType;
        int newSortTypeNumber = (sortTypeNumber + 1) % (int)SortType.Max;
        _sortType = (SortType)newSortTypeNumber;

        Refresh();
    }

    private void Refresh()
    {
        _infiniteScroll.Clear();
        foreach (var item in _userItems)
        {
            _infiniteScroll.InsertData(new InventoryItemSlotData() { UserInventoryData = item });
        }
        _infiniteScroll.SetFilter(OnFilter);

        _filterBtnTxt.text = GetFilterButtonText();

        _sortBtnTxt.text = GetSortButtonText();

        SortInventory();
    }

    private void SortInventory()
    {
        _infiniteScroll.SortList((lhs, rhs) =>
        {
            var lhsData = lhs.data as InventoryItemSlotData;
            var rhsData = rhs.data as InventoryItemSlotData;

            int compareResult = 0;
            switch (_sortType)
            {
                case SortType.Grade:
                    compareResult = CompareByGrade(lhsData, rhsData);
                    if (compareResult == 0)
                    {
                        compareResult = CompareByLevel(lhsData, rhsData);
                    }
                    break;
                case SortType.Level:
                    compareResult = CompareByLevel(lhsData, rhsData);
                    if (compareResult == 0)
                    {
                        compareResult = CompareByGrade(lhsData, rhsData);
                    }
                    break;

            }

            return compareResult;
        });
    }
    
    private int CompareByLevel(InventoryItemSlotData lhs, InventoryItemSlotData rhs)
    {
        int lhsLevel = lhs.UserInventoryData.item_level;
        int rhsLevel = rhs.UserInventoryData.item_level;

        return rhsLevel.CompareTo(lhsLevel);
    }

    private int CompareByGrade(InventoryItemSlotData lhs, InventoryItemSlotData rhs)
    {
        var lhsGrade = ItemModel.GetGrade(lhs.UserInventoryData.item_id);
        var rhsGrade = ItemModel.GetGrade(rhs.UserInventoryData.item_id);

        return rhsGrade.CompareTo(lhsGrade);
    }

    private string GetSortButtonText() => _sortType switch
    {
        SortType.Grade => "등급",
        SortType.Level => "레벨",
        _ => null
    };

    private string GetFilterButtonText() => _filterType switch
    {
        FilterType.All => "모든 장비",
        FilterType.Weapon => "무기",
        FilterType.Shield => "방패",
        FilterType.ChestArmor => "갑옷",
        FilterType.Gloves => "장갑",
        FilterType.Boots => "신발",
        FilterType.Accessery => "악세서리",
        _ => null,
    };

    private bool OnFilter(InfiniteScrollData data)
    {
        if (_filterType == FilterType.All)
        {
            return false;
        }

        var slotData = data as InventoryItemSlotData;
        return (int)_filterType != (int)ItemModel.GetType(slotData.UserInventoryData.item_id);
    }
}
