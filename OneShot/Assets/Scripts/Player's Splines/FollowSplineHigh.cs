using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSplineHigh : MonoBehaviour
{

    private Coroutine coroutine;
    public SplineContainer SplineLinear;
    public float duration = TimingController2.Instance.startTimer * 3;

    public float progress = 0f;

    void Start()
    {
        transform.position = SplineLinear.transform.TransformPoint(SplineLinear.Spline.EvaluatePosition(0));
        duration = TimingController2.Instance.startTimer * 3;
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

            ISpline spline = SplineLinear.Spline;
            Vector3 position3D = spline.EvaluatePosition(progress);
            Vector3 worldPosition = SplineLinear.transform.TransformPoint(position3D);
            transform.position = new Vector2(worldPosition.x, worldPosition.y);

            yield return null;
        }

        // Fin
    }
}
