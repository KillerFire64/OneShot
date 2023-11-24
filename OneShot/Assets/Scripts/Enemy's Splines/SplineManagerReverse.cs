using UnityEngine;

public class SplineManagerReverse : MonoBehaviour
{
    public MonoBehaviour followSplineHighReverse;
    public MonoBehaviour followSplineLinearReverse;
    public MonoBehaviour followSplineLowReverse;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnableSplineScript(followSplineLinearReverse);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            EnableSplineScript(followSplineHighReverse);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            EnableSplineScript(followSplineLowReverse);
        }
    }

    private void EnableSplineScript(MonoBehaviour scriptToEnable)
    {
        followSplineHighReverse.enabled = false;
        followSplineLinearReverse.enabled = false;
        followSplineLowReverse.enabled = false;

        scriptToEnable.enabled = true;

        // If needed, call a Reset method to set initial states
        // scriptToEnable.ResetProgress(); // Uncomment if you have a ResetProgress or similar method
    }
}
