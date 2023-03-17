using UnityEngine;
using System.IO;
using System.Collections;
using System;

public class Audio : MonoBehaviour
{

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    public AudioSource source;

    private void Awake()
    {

        volume = 0.5f;
        pitch = 1f;

    }
    private void Start()
    {
        source.volume = volume;
        source.pitch = pitch;


    }

    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            PlayandPause();
        }
        source.volume = volume;
        source.pitch = pitch;
    }
    public void PlayandPause()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }
    public static implicit operator AudioClip(Audio v)
    {
        throw new NotImplementedException();
    }
}