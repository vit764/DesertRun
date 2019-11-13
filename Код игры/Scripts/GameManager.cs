using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Animator ac;

    public GameObject ResultObj;
    public PlayerMovement Pm;
    public RoadSpawner Rs;
    public PauseMenuController PauseM;

    public float MoveSpeed, StartMoveSpeed,
                 PointsByValue,
                 PointsMultiplayer, StartPointsMultiplayer,
                 PowerUpMultiplier;

    public int gems;

    public int bestResult,
               allGems;

    float points;

    public bool canPlay = false;

    public Text PointTxt,
                GemsTxt;

    public List<Skin> Skins;

    public void startGame()
    {
        
        Pm.Respawn();
        MoveSpeed = StartMoveSpeed;
        PointsMultiplayer = StartPointsMultiplayer;
        ResultObj.SetActive(false);
        Rs.StartGame();
        canPlay = true;
        Pm.ac.SetTrigger("respawn");
        StartCoroutine(FixTrigger());
        points = 0;
        PointTxt.text = ((int)points).ToString();
        gems = 0;
        GemsTxt.text = ((int)gems).ToString();

    }

    IEnumerator FixTrigger()
    {
        yield return null;
        Pm.ac.ResetTrigger("respawn");
    }

    private void Update()
    {
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseM.Pause();
            points += PointsByValue * PointsMultiplayer* PowerUpMultiplier * Time.deltaTime;

            PointsMultiplayer += 0.05f * Time.deltaTime;
            PointsMultiplayer = Mathf.Clamp(PointsMultiplayer, 1, 10);

            MoveSpeed += 0.1f * Time.deltaTime;
            MoveSpeed = Mathf.Clamp(MoveSpeed, 10, 25);
        }
        PointTxt.text = ((int)points).ToString(); 
       
    }
     
    public void showResult()
    {
        ResultObj.SetActive(true);
    }

    public void addGems(int num)
    {
        gems += num;
        GemsTxt.text = gems.ToString();
    }

    public void updData()
    {
        if ((int)points > bestResult)
            bestResult = (int)points;
        allGems += gems;
        SaveManager.Instance.SaveGame();
    }

    public void ActivateSkin(int skinIndex,bool setTrigger = false)
    {
        foreach(var skin in Skins)
            skin.HideSkin();
        Skins[skinIndex].ShowSkin();
        Pm.ac = Skins[skinIndex].AC;
        if(setTrigger)
        Pm.ac.SetTrigger("death");
    }
}
