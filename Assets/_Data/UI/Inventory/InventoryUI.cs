using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : SingletonPattern<InventoryUI>
{
    protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected Transform showHide;

    [SerializeField] protected ButtonItemInventory defaultItemInventoryUI;
    protected List<ButtonItemInventory> buttonItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }

    protected override void Start()
    {
        base.Start();
        this.Hide();
        this.HideDefaultItemInventory();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButtonItemInventory();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if(this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
    }

    protected virtual void LoadButtonItemInventory()
    {
        if(this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<ButtonItemInventory>();
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.showHide.gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if(this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        if(!this.isShow) return;
        Debug.Log("Item Updating");

        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach(ItemInventory itemInventory in itemInvCtrl.Items)
        {
            ButtonItemInventory newButtonItem = this.GetExistItem(itemInventory);
            if(newButtonItem == null)
            {
                newButtonItem = Instantiate(this.defaultItemInventoryUI);
                newButtonItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newButtonItem.SetItem(itemInventory);
                newButtonItem.transform.localScale = new Vector3(1, 1, 1);
                newButtonItem.gameObject.SetActive(true);
                newButtonItem.name = itemInventory.itemName + " - " + itemInventory.ItemID;
                this.buttonItems.Add(newButtonItem);
            }
        }
    }

    protected virtual ButtonItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach(ButtonItemInventory itemInvUI in this.buttonItems)
        {
            if(itemInvUI.ItemInventory.ItemID == itemInventory.ItemID) return itemInvUI;
        }
        return null;
    }

    protected virtual void HotkeyToogleInventory()
    {
        if(InputHotkeys.Instance.IsToogleInventoryUI) this.Toggle();
    }
}