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

    public void ShootStandartBullet()
    {
        timer = startTimer * 2;
        isShooting = true;
    }

    public void ShootDownBullet()
    {
        timer = startTimer;
        isShooting = true;
    }

    public void ShootUpBullet()
    {
        timer = startTimer * 3;
        isShooting = true;
    }
}
