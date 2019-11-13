using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockMov : MonoBehaviour
{
    GameManager gm;
    Vector3 moveVec;

    public GameObject GemsObj;
    public GameObject AddGemsObj;
    public GameObject[] PowerUpObj;

    public int GemChance;
    // Start is called before the first frame update
    void Start()
    {

        BonusManager.GemsPowerUpEvent += GemsEvent;
        gm = FindObjectOfType<GameManager>();
        moveVec = new Vector3(-1, 0, 0);
        GemsObj.SetActive(Random.Range(0, 101) <= GemChance);
        foreach(GameObject powerup in PowerUpObj)
        {
            powerup.SetActive(false);
        }
        PowerUpObj[Random.Range(0, PowerUpObj.Length)].SetActive(Random.Range(0, 101) <= 80 - GemChance);
        AddGemsObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.canPlay)
        {
            transform.Translate(moveVec * Time.deltaTime * gm.MoveSpeed);
        }
    }

    void GemsEvent(bool activate)
    {
        if(activate)
        {
            AddGemsObj.SetActive(true);
            return;
        }
        else
            AddGemsObj.SetActive(false);
    }
    private void OnDestroy()
    {
        BonusManager.GemsPowerUpEvent -= GemsEvent;
    }
}
