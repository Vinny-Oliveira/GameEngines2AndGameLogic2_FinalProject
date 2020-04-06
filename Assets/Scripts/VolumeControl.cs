using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMasterVol(float volMaster)
    {
        masterMixer.SetFloat("volMaster", volMaster);
    }

    public void SetSfxVol(float volSFXs)
    {
        masterMixer.SetFloat("volSFXs", volSFXs);
    }

    public void SetMusicVol(float volMusic)
    {
        masterMixer.SetFloat("volMusic", volMusic);
    }

    public void SetMenuSoundsVol(float volMenuSounds)
    {
        masterMixer.SetFloat("volMenuSounds", volMenuSounds);
    }
}
