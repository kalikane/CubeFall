using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFx;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, GameOverClip;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LandSound()
    {
        soundFx.clip = landClip;
        soundFx.Play();
    }
    public void IceBreakSound()
    {
        soundFx.clip = iceBreakClip;
        soundFx.Play();
    }

    public void GameOverSound()
    {
        soundFx.clip = GameOverClip;
        soundFx.Play();
    }

    public void DeathSound()
    {
        soundFx.clip = deathClip;
        soundFx.Play();
    }
}
