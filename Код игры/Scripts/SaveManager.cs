using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public ShopManager SM;
    public GameManager GM;

    string filePath;

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        GM = FindObjectOfType<GameManager>();
        filePath = Application.persistentDataPath + "data.gamesave";

        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.allGems = GM.allGems;
        save.bestResult = GM.bestResult;
        save.ActiveSkinIndex = (int)SM.ActiveSkin;
        save.SaveBoughtItems(SM.Items);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);

        GM.allGems = save.allGems;
        GM.bestResult = save.bestResult;
        SM.ActiveSkin = (ShopItem.ItemType)save.ActiveSkinIndex;

        for (int i = 0; i < save.BoughtItems.Count; i++)
            SM.Items[i].IsBought = save.BoughtItems[i];

        fs.Close();

        SM.RefreshText();
        GM.ActivateSkin((int)SM.ActiveSkin);
    }

    public void ResetGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.allGems = 0;
        save.bestResult = 0;
        save.ActiveSkinIndex = 0;
        save.ResetBoughtItems(SM.Items);

        bf.Serialize(fs, save);
        fs.Close();
    }


}

[System.Serializable]
public class Save
{
    public int allGems;
    public int bestResult;
    public int ActiveSkinIndex;
    public List<bool> BoughtItems = new List<bool>();

    public void SaveBoughtItems(List<ShopItem> items)
    {
        foreach (var item in items)
            BoughtItems.Add(item.IsBought);
    }

    public void ResetBoughtItems(List<ShopItem> items)
    {
        BoughtItems.Add(false);
        for (int i = 1; i<items.Count;i++)
        {
            BoughtItems.Add(false);
        }
    }
}
