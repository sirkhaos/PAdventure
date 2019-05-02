using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audios;
    public float maxVolumeLevel, currentVolumeLevel;

    // Start is called before the first frame update
    void Start()
    {
        audios = FindObjectsOfType<AudioVolumeController>();
        ChangeGlobalAudioVolumen();
    }

    public void ChangeGlobalAudioVolumen()
    {
        if (currentVolumeLevel >= maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }
        foreach(AudioVolumeController avc in audios)
        {
            avc.setAudioLevel(currentVolumeLevel);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeGlobalAudioVolumen();
    }
}
