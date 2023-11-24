using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAngleMouse : MonoBehaviour
{
    public GameObject Player;
    public GameObject CenterOfRotation;
    private Vector2 _currentMousePosition;
    public float angle;

    public float timer;
    public float startTimer;

    public bool isShooting;

    public static FindAngleMouse Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(isShooting)
        {
            timer -= Time.deltaTime;
        }
        

        _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var mousePos_xy = new Vector2(_currentMousePosition.x, _currentMousePosition.y);
        var center_xy = new Vector2(CenterOfRotation.transform.localPosition.x, CenterOfRotation.transform.localPosition.y);

        var vector1 = center_xy - mousePos_xy; // VectorToMoveTo
        var vector2 = center_xy - new Vector2(Player.transform.position.x, Player.transform.position.y); // Vector at the center line of the bottle.

        angle = Vector2.Angle(vector1.normalized, vector2.normalized);

        if(timer <= 0 )
        {
            timer = startTimer;
            TimingController2.Instance.EnemySwing();
            TimingController2.Instance.CallBullet();
            isShooting = false;
        }

    }

    public void ShootBullet()
    {
        if (angle >= 30 && _currentMousePosition.y > CenterOfRotation.transform.localPosition.y)
        {
            Debug.Log("EN HAUUUUT");
            timer = startTimer * 3;
        }
        else if (angle >= 30 && _currentMousePosition.y < CenterOfRotation.transform.localPosition.y)
        {
            Debug.Log("EN BAAAAS");
            timer = startTimer;
        }
        else
        {
            Debug.Log("AU CEEENTRE");
            timer = startTimer * 2;
        }

        isShooting = true;
    }
}
