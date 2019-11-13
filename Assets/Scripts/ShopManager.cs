using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> Items;
    public ShopItem.ItemType ActiveSkin;

    public GameManager gm;

    public Text AllGemsTxt;

    public Button LeftBtn, RightBtn;

    int currentItem;

    public void OpenShop()
    {
        CheckItemButtons();
        gameObject.SetActive(true);
        RefreshText();
        foreach (ShopItem item in Items)
        {
            item.DisableScreen();
        }
        currentItem = 0;
        Items[currentItem].ActivateScreen();
        CheckShopBtn();
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    public void CheckItemButtons()
    {
        foreach (ShopItem item in Items)
        {
            item.SM = this;
            item.Init();
            item.CheckButtons();
        }
    }

    public void RightBtnPressed()
    {
        Items[currentItem].DisableScreen();
        currentItem++;
        Items[currentItem].ActivateScreen();
        CheckShopBtn();
    }

    public void LeftBtnPressed()
    {
        Items[currentItem].DisableScreen();
        currentItem--;
        Items[currentItem].ActivateScreen();
        CheckShopBtn();
    }

    private void CheckShopBtn()
    {
        if (currentItem == (Items.Count-1))
            RightBtn.interactable = false;
        else
            RightBtn.interactable = true;
        if (currentItem == 0)
            LeftBtn.interactable = false;
        else
            LeftBtn.interactable = true;
    }


    public void RefreshText()
    {
        AllGemsTxt.text = gm.allGems.ToString();
    }
}
