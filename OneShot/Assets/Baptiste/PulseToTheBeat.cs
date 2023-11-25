using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseToTheBeat : MonoBehaviour
{
    public bool useTestBeat;
    public float pulseSize;
    public float returnSpeed;

    private Vector3 startSize;

    private void Start()
    {
        startSize = transform.localScale;
        if (useTestBeat )
        {
            StartCoroutine(TestBeat());
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * returnSpeed);
    }

    public void Pulse()
    {
        transform.localScale = startSize * pulseSize;
    }

    IEnumerator TestBeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Pulse();
        }
    }
}
