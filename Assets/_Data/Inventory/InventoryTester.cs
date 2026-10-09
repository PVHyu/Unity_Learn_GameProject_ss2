using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryTester : BaseMonoBehaviour
{
    [ProButton]
    public virtual void AddTestItems(int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for(int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory
            (
                InventoryManager.Instance.GetProfileByCode(ItemCode.Wand),
                 1
            );
            items.AddItem(wand);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for(int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory
            (
                InventoryManager.Instance.GetProfileByCode(ItemCode.Wand),
                 1
            );

            items.RemoveItem(wand);
        }
    }

    [ProButton]
    public virtual void AddTestGold(int count)
    {
        InventoryCtrl monies = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency);

        ItemInventory gold = new ItemInventory
            (
                InventoryManager.Instance.GetProfileByCode(ItemCode.Gold),
                 1
            );
        monies.AddItem(gold);
    }

    [ProButton]
    public virtual void RemoveTestGold(int count)
    {
        InventoryCtrl monies = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency);

        ItemInventory gold = new ItemInventory
            (
                InventoryManager.Instance.GetProfileByCode(ItemCode.Gold),
                 1
            );
        monies.RemoveItem(gold);
    }
}