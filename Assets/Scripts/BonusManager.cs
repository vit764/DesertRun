using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public struct PowerUp
    {
        public enum Type
        {
            MUILTIPLIER,
            IMMORTALITY,
            GEMSEVERYWHERE
        }
        public Type PowerUpType;
        public float Duration;
    }

    public delegate void OnGemsPowerUp(bool activate);
    public static event OnGemsPowerUp GemsPowerUpEvent;

    PowerUp[] powerUps = new PowerUp[3];
    Coroutine[] powerUpsCors = new Coroutine[3];
    bool[] CorsStop = new bool[3];

    public GameManager GM;
    public PlayerMovement PM;

    public GameObject Bonus;
    public Transform BonusGrid;
    List<BonusScr> powerups = new List<BonusScr>();

    void Start()
    {
        powerUps[0] = new PowerUp() { PowerUpType = PowerUp.Type.MUILTIPLIER, Duration = 6 };
        powerUps[1] = new PowerUp() { PowerUpType = PowerUp.Type.IMMORTALITY, Duration = 4 };
        powerUps[2] = new PowerUp() { PowerUpType = PowerUp.Type.GEMSEVERYWHERE, Duration = 5 };

        PlayerMovement.PowerUpUseEvent += PowerUpUse;
    }

    void PowerUpUse(PowerUp.Type type)
    {
        if (powerUpsCors[(int)type] == null)
        {
            //PowerUpReset(type);
            powerUpsCors[(int)type] = StartCoroutine(PowerUpCor(type, CreateBonus(type)));

            switch (type)
            {
                case PowerUp.Type.MUILTIPLIER:
                    GM.PowerUpMultiplier = 2;

                    break;
                case PowerUp.Type.IMMORTALITY:
                    PM.ImmortalityOn();

                    break;
                case PowerUp.Type.GEMSEVERYWHERE:
                    if (GemsPowerUpEvent != null)
                        GemsPowerUpEvent(true);

                    break;
            }
        }
    }

    void PowerUpReset(PowerUp.Type type)
    {
        if (powerUpsCors[(int)type] != null)
        {
            StopCoroutine(powerUpsCors[(int)type]);
        }
        else
            return;

        powerUpsCors[(int)type] = null;

        switch (type)
        {
            case PowerUp.Type.MUILTIPLIER:
                GM.PowerUpMultiplier = 1;
               
                break;
            case PowerUp.Type.IMMORTALITY:
                PM.ImmortalityOff();
                
                break;
            case PowerUp.Type.GEMSEVERYWHERE:
                if (GemsPowerUpEvent != null)
                    GemsPowerUpEvent(false);
              
                break;
        }
    }

    public void ResetAllPowerUps()
    {
        for (int i = 0; i < powerUps.Length; i++)
            PowerUpReset(powerUps[i].PowerUpType);

        foreach (var pu in powerups)
            pu.Destroy();

        powerups.Clear();
    }

    IEnumerator PowerUpCor(PowerUp.Type type, BonusScr Bonus)
    {
        float duration = powerUps[(int)type].Duration;
        float currDuration = duration;
       
        while (currDuration > 0)
        {
            Bonus.SetProgress(currDuration / duration);

            if (GM.canPlay)
                currDuration -= Time.deltaTime;

          
            yield return null;
        }

        powerups.Remove(Bonus);
        Bonus.Destroy();

        PowerUpReset(type);
        
    }

   BonusScr CreateBonus(PowerUp.Type type)
    {
        GameObject go = Instantiate(Bonus, BonusGrid, false);

        var ps = go.GetComponent<BonusScr>();

        powerups.Add(ps);

        ps.SetData(type);
        return ps;
    }
}
