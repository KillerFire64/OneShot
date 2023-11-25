using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecaledBeatManager : MonoBehaviour
{
    public float bpm;
    public float sampledTime;
    public AudioSource audioSource;
    public BeatIntervals[] intervals;

    private void Update()
    {
        foreach (BeatIntervals interval in intervals)
        {
            sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLenght(bpm)) - 0.01f);
            interval.CheckForNewInterval(sampledTime);
        }
    }
}
