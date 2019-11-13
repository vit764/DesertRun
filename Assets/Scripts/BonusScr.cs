using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BonusScr : MonoBehaviour
{
    public Image Progressbar;
    public Color[] Colors;

    public void SetData(BonusManager.PowerUp.Type type)
    {
        Progressbar.color = Colors[(int)type];
    }

    public void SetProgress(float progress)
    {
        Progressbar.fillAmount = progress;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
