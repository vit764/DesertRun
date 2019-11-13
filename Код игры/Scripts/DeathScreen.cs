using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public MenuController MC;
    public GameManager Gm;

   
    public void RespawnBtn()
    {
        Gm.startGame();
    }

    public void MenuBtn()
    {
        gameObject.SetActive(false);
        MC.OpenMenu();
    }
}
