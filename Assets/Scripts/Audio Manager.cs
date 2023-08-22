using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] musicTracks; // Array of your music Audio Sources
    public AudioClip[] audioClip;
    private int currentTrackIndex = 0; // Index of the currently playing track
    private bool Switch;

    private void Start()
    {
        // Start playing the first track
        PlayCurrentTrack();
    }

    private void PlayCurrentTrack()
    {
        musicTracks[currentTrackIndex].Play();
        StartCoroutine(WaitForTrackEnd());
    }
    private IEnumerator WaitForTrackEnd()
    {
        while (musicTracks[currentTrackIndex].time < audioClip[currentTrackIndex].length)
        {
            Switch = false;
            yield return null;
        }      
        Switch = true;
        if (Switch)
        {
            yield return new WaitForSeconds(5);
            SwitchToNextTrack();
        }
    }

    private void SwitchToNextTrack()
    {
        // Stop the current track
        musicTracks[currentTrackIndex].Stop();

        // Move to the next track
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

        // Play the new track
        PlayCurrentTrack();
    }
}
