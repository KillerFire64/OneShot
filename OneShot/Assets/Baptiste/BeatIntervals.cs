using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatIntervals : MonoBehaviour
{
    public static BeatIntervals Instance;

    private void Awake()
    {
        Instance = this;
    }

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
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
