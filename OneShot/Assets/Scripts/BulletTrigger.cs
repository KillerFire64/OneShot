using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    // Reference to the SplineManagerReverse component on the bullet
    public SplineManagerReverse bulletSplineManagerReverse;

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        // Check if the triggering object is a Bullet
        if (other.CompareTag("Bullet"))
        {
            // Call the method to enable a random spline script
            bulletSplineManagerReverse.EnableRandomSplineScript();
        }
    }
}
