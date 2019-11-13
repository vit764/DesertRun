using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    public Slider BackSlider, EffectSlider;

    public AudioManager AudioM;
    public void BackSliderChenged()
    {
        AudioM.BackMusic.volume = BackSlider.value;
    }

    public void EffectSliderChenged()
    {
        AudioM.EffectMusic.volume = EffectSlider.value;
    }

    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        gameObject.SetActive(true);
    }
    
}
