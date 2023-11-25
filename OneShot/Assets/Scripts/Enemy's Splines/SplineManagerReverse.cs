using UnityEngine;

public class SplineManagerReverse : MonoBehaviour
{
    public MonoBehaviour followSplineHighReverse;
    public MonoBehaviour followSplineLinearReverse;
    public MonoBehaviour followSplineLowReverse;

    public FollowSplineHighReverse splineHigh;
    public FollowSplineLinearReverse splineLinear;
    public FollowSplineLowReverse splineLow;

    public static SplineManagerReverse Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if (TimingController2.Instance.randomReactionSpeed == 0)
        {
            EnableSplineScriptReverse(followSplineLinearReverse);
            splineLinear.duration = TimingController2.Instance.startTimer * 2;
        }
        else if (TimingController2.Instance.randomReactionSpeed == 1)
        {
            EnableSplineScriptReverse(followSplineHighReverse);
            splineHigh.duration = TimingController2.Instance.startTimer * 3;
        }
        else if (TimingController2.Instance.randomReactionSpeed == 2)
        {
            EnableSplineScriptReverse(followSplineLowReverse);
            splineLow.duration = TimingController2.Instance.startTimer;
        }
    }

    // Method to enable a random spline script
    /*public void EnableRandomSplineScriptReverse()
    {
        // Randomly pick one of the spline scripts
        MonoBehaviour[] splines = new MonoBehaviour[] {
            followSplineLinearReverse,
            followSplineHighReverse,
            followSplineLowReverse
        };

        EnableSplineScriptReverse(splines[TimingController2.Instance.randomReactionSpeed]);
    }*/

    private void EnableSplineScriptReverse(MonoBehaviour scriptToEnable)
    {
        // Disable all spline scripts first
        followSplineHighReverse.enabled = false;
        followSplineLinearReverse.enabled = false;
        followSplineLowReverse.enabled = false;


        // Enable the selected spline script
        scriptToEnable.enabled = true;

        // If needed, call a Reset method to set initial states
        // (scriptToEnable as FollowSplineBase)?.ResetProgress(); // Assuming you cast to a base class with a ResetProgress method
    }
}
