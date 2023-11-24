using UnityEngine;
using UnityEngine.Splines;

public class FollowSplineHigh : MonoBehaviour
{
    public SplineContainer SplineLinear;
    public float duration = 5f;

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
    }
}
