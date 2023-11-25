using UnityEngine;

public class SplineManager : MonoBehaviour
{
    public MonoBehaviour followSplineHigh;
    public MonoBehaviour followSplineLinear;
    public MonoBehaviour followSplineLow;

    public FollowSplineHigh splineHigh;
    public FollowSplineLinear splineLinear;
    public FollowSplineLow splineLow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && splineLinear.progress <= 0.1f)
        {
            EnableSplineScript(followSplineLinear);
            splineLinear.duration = TimingController2.Instance.startTimer * 2;
        }
        else if (Input.GetKeyDown(KeyCode.E) && splineLow.progress <= 0.1f)
        {
            EnableSplineScript(followSplineLow);
            splineLow.duration = TimingController2.Instance.startTimer;
        }
        else if (Input.GetKeyDown(KeyCode.T) && splineHigh.progress <= 0.1f)
        {
            EnableSplineScript(followSplineHigh);
            splineHigh.duration = TimingController2.Instance.startTimer * 4;
        }
    }

    private void EnableSplineScript(MonoBehaviour scriptToEnable)
    {
        followSplineHigh.enabled = false;
        followSplineLinear.enabled = false;
        followSplineLow.enabled = false;

        scriptToEnable.enabled = true;

        // If needed, call a Reset method to set initial states
        // scriptToEnable.ResetProgress(); // Uncomment if you have a ResetProgress or similar method
    }
}
