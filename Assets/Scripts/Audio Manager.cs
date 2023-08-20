using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] musicTracks; // Array of your music Audio Sources
    private int currentTrackIndex = 0; // Index of the currently playing track

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
        while (musicTracks[currentTrackIndex].isPlaying)
        {
            yield return null;
        }

        // The current track has finished playing, switch to the next track
        yield return new WaitForSeconds(5f);
        SwitchToNextTrack();
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
