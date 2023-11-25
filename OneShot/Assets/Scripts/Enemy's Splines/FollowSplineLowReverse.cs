using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSplineLowReverse : MonoBehaviour
{
    private Coroutine coroutine;
    public SplineContainer SplineLinearReverse;
    public float duration = TimingController2.Instance.startTimer;

    public float progress = 0f;

    void Start()
    {
        transform.position = SplineLinearReverse.transform.TransformPoint(SplineLinearReverse.Spline.EvaluatePosition(0));
        duration = TimingController2.Instance.startTimer;
    }



    public void StartTravel()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(CO_Travel());
    }

    private IEnumerator CO_Travel()
    {
        // Début
        progress = 0;

        float currentDuration = 0f;
        while (currentDuration <= duration)
        {
            // Update

            currentDuration = currentDuration + Time.deltaTime;
            progress = Mathf.Clamp01(currentDuration / duration);

            ISpline spline = SplineLinearReverse.Spline;
            Vector3 position3D = spline.EvaluatePosition(progress);
            Vector3 worldPosition = SplineLinearReverse.transform.TransformPoint(position3D);
            transform.position = new Vector2(worldPosition.x, worldPosition.y);

            yield return null;
        }

        // Fin
    }
}
