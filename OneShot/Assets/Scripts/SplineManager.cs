using UnityEngine;

public class SplineManager : MonoBehaviour
{
    public MonoBehaviour followSplineHigh;
    public MonoBehaviour followSplineLinear;
    public MonoBehaviour followSplineLow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EnableSplineScript(followSplineLinear);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            EnableSplineScript(followSplineHigh);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            EnableSplineScript(followSplineLow);
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
