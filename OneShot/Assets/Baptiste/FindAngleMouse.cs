using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAngleMouse : MonoBehaviour
{

    public FollowSplineHigh splineHigh;
    public FollowSplineLinear splineLinear;
    public FollowSplineLow splineLow;

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
        timer = startTimer * 2f;
        isShooting = true;
        splineLinear.StartTravel();
    }

    public void ShootDownBullet()
    {
        timer = startTimer;
        isShooting = true;
        splineLow.StartTravel();
    }

    public void ShootUpBullet()
    {
        timer = startTimer * 3;
        isShooting = true;
        splineHigh.StartTravel();
    }
}
