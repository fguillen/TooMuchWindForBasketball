using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip[] bouncingClips;
    AudioSource audioSource;
    public static BallAudioController instance;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    public void BouncingSound()
    {
        AudioClip clip = bouncingClips[Random.Range(0, bouncingClips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
