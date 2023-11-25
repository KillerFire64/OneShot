using UnityEngine;

public class SplineManagerReverse : MonoBehaviour
{
    public MonoBehaviour followSplineHighReverse;
    public MonoBehaviour followSplineLinearReverse;
    public MonoBehaviour followSplineLowReverse;

    // Method to enable a random spline script
    public void EnableRandomSplineScript()
    {
        // Randomly pick one of the spline scripts
        MonoBehaviour[] splines = new MonoBehaviour[] {
            followSplineHighReverse,
            followSplineLinearReverse,
            followSplineLowReverse
        };

        // Randomly pick and enable one of the scripts
        EnableSplineScript(splines[Random.Range(0, splines.Length)]);
    }

    private void EnableSplineScript(MonoBehaviour scriptToEnable)
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
