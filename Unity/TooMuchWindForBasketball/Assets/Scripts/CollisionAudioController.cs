using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] collisionClips;
    [SerializeField] Vector2 soundVolumeLimits;
    [SerializeField] Vector2 collisionMagnitudeLimits;
    [SerializeField] float minimumTimeBetweenSounds;
    float minimumTimeBetweenSoundsCounter;

    AudioSource audioSource;
    LinearProportionConverter magnitudeToVolume;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        IniMagnitudeToVolume();
    }

    void Update()
    {
        minimumTimeBetweenSoundsCounter -= Time.deltaTime;
    }
    
    void PlayCollisionSound(float magnitude)
    {
        float volume = magnitudeToVolume.CalculateDimension1Value(magnitude);
        minimumTimeBetweenSoundsCounter = minimumTimeBetweenSounds;

        print("PlayCollisionSound. magnitude: " + magnitude + ", volume: " + volume);

        // If volume is above maximum we put maximum
        if(volume > soundVolumeLimits.y)
            volume = soundVolumeLimits.y;

        // If volume is not the minimum we don't make sound at all
        if(volume > soundVolumeLimits.x)
        {
            AudioClip clip = collisionClips[Random.Range(0, collisionClips.Length)];
            audioSource.PlayOneShot(clip, volume);
        }
    }

    void IniMagnitudeToVolume()
    {
        magnitudeToVolume = new LinearProportionConverter(soundVolumeLimits.x, soundVolumeLimits.y, collisionMagnitudeLimits.x, collisionMagnitudeLimits.y);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(minimumTimeBetweenSoundsCounter <= 0)
        {
            float magnitude = collisionInfo.relativeVelocity.magnitude;
            PlayCollisionSound(magnitude);
        }
    }
}
