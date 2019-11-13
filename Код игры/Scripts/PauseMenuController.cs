using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameManager GM;
    public MenuController MC;
    public PlayerMovement PM;

    public void Pause()
    {
        gameObject.SetActive(true);
        GM.canPlay = false;
        PM.Pause();
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        GM.canPlay = true;
        PM.UnPause();
    }

    public void MenuBtn()
    {
        PM.UnPause();
        PM.bm.ResetAllPowerUps();

        gameObject.SetActive(false);
        MC.OpenMenu();
    }
}
