using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public float bpm;
    public float sampledTime;
    public AudioSource audioSource;
    public Intervals[] intervals;

    private void Update()
    {
        foreach (Intervals interval in intervals)
        {
            sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLenght(bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}

[System.Serializable]
public class Intervals
{

    [SerializeField] public float steps;
    [SerializeField] public UnityEvent trigger;
    public float intervalLenght;

    private int lastInterval;

    public float GetIntervalLenght(float _bpm)
    {
        intervalLenght = 60f / (_bpm * steps);
        return intervalLenght;
    }

    public void CheckForNewInterval(float interval)
    {
        if(Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
