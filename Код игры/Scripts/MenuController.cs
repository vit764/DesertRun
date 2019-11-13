using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameManager GM;
    public Text BestResultTxt;
    public ShopManager SM;
    public OptionsController OM;
    //public SaveManager SaveManager;


    public void StartBtn()
    {
        gameObject.SetActive(false);
        GM.startGame();
    }

    public void ShopBtn()
    {
        SM.OpenShop();
    }

    public void OptionsBtn()
    {
        OM.OpenOptions();
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        BestResultTxt.text = GM.bestResult.ToString();
    }

    public void ResetBtn()
    {
        SaveManager.Instance.ResetGame();
        SaveManager.Instance.LoadGame();
        BestResultTxt.text = GM.bestResult.ToString();
    }

}
