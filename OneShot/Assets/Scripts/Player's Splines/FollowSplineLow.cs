using System.Collections;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class FollowSplineLow : MonoBehaviour
{
    public SplineContainer SplineLinear;
    public float duration = TimingController2.Instance.startTimer;

    public float progress = 0f;

    private Coroutine coroutine;

    void Start()
    {
        transform.position = SplineLinear.transform.TransformPoint(SplineLinear.Spline.EvaluatePosition(0));
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

            ISpline spline = SplineLinear.Spline;
            Vector3 position3D = spline.EvaluatePosition(progress);
            Vector3 worldPosition = SplineLinear.transform.TransformPoint(position3D);
            transform.position = new Vector2(worldPosition.x, worldPosition.y);

            yield return null;
        }

        // Fin
    }
}
