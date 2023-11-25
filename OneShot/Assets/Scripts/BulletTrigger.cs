using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletTrigger : MonoBehaviour
{
    public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && FindAngleMouse.Instance.isShooting == true)
        {
            Debug.Log("t'es mort");
            Destroy(bullet);
            SceneManager.LoadScene(2);
        }
    }
}
