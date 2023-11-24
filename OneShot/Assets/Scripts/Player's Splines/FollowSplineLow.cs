using UnityEngine;
using UnityEngine.Splines;

public class FollowSplineLow : MonoBehaviour
{
    public SplineContainer SplineLinear;
    public float duration = 2f;

    private float progress = 0f;

    void Start()
    {
        transform.position = SplineLinear.transform.TransformPoint(SplineLinear.Spline.EvaluatePosition(0));
    }

    void Update()
    {
        if (progress < 1f)
        {
            progress += Time.deltaTime / duration;
            progress = Mathf.Clamp01(progress);
            ISpline spline = SplineLinear.Spline;
            Vector3 position3D = spline.EvaluatePosition(progress);

            Vector3 worldPosition = SplineLinear.transform.TransformPoint(position3D);

            transform.position = new Vector2(worldPosition.x, worldPosition.y);
        }
        if (duration > 0)
        {
            progress += Time.deltaTime / duration;
            progress = Mathf.Clamp01(progress);

            if (progress >= 1f)
            {
                // If the object has reached the end of the spline, reset progress and duration
                ResetProgressAndDuration();
            }
        }
        else
        {
            // If the duration is 0 or less, reset progress
            ResetProgress();
        }
    }
    public void ResetProgress()
    {
        progress = 0f;
    }

    private void ResetProgressAndDuration()
    {
        progress = 0f;
        duration = 2f; 
    }
}
