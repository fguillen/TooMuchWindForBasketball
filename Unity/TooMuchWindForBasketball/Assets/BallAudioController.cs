using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip[] bouncingClips;
    AudioSource audioSource;
    public static BallAudioController instance;

    LinearProportionConverter magnitudeToVolume;

    [SerializeField] Vector2 bouncingVolumeLimits;
    [SerializeField] Vector2 bouncingMagnitudeLimits;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        IniMagnitudeToVolume();
    }
    
    public void BouncingSound(float magnitude)
    {
        float volume = magnitudeToVolume.CalculateDimension1Value(magnitude);
        print("volume: " + volume);

        if(volume > bouncingVolumeLimits.y)
            volume = bouncingVolumeLimits.y;

        if(volume > bouncingVolumeLimits.x)
        {
            AudioClip clip = bouncingClips[Random.Range(0, bouncingClips.Length)];
            audioSource.PlayOneShot(clip, volume);
        }
    }

    void IniMagnitudeToVolume()
    {
        magnitudeToVolume = new LinearProportionConverter(bouncingVolumeLimits.x, bouncingVolumeLimits.y, bouncingMagnitudeLimits.x, bouncingMagnitudeLimits.y);
    }
}
