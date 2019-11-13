using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackMusic, EffectMusic;
    public AudioClip GemEffect;

    public void PlayGemEffect()
    {
        EffectMusic.PlayOneShot(GemEffect);
    }
}
