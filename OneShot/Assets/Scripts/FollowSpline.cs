using UnityEngine;
using UnityEngine.Splines;

public class FollowSpline : MonoBehaviour
{
    public SplineContainer SplineLinear;
    public float duration = 5f;

    private float progress = 0f;

    void Update()
    {
        if (progress < 1f)
        {
            progress += Time.deltaTime / duration;
            progress = Mathf.Clamp01(progress);
            ISpline spline = SplineLinear.Spline;
            Vector3 position3D = spline.EvaluatePosition(progress);
            Vector2 position2D = new Vector2(position3D.x, position3D.y);
            float zRotation = 0;
            transform.position = position2D;
        }
    }
}
