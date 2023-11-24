using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingController2 : MonoBehaviour
{
    BulletType currentBulletType;

    public SpriteRenderer whiteRect;
    public GameObject hitInfo;

    private int randomReactionSpeed;
    public float timer;

    public float startTimer;
    public float deathTime;

    public float clickGreenTimer;
    public float startGreenTimer;

    public bool isCallingBullet;
    private bool isGreen;
    private bool isDead;
    public bool successfulClick;
    public bool playerSwing;

    public static TimingController2 Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isDead = false;
        timer = startTimer - 0.1f;
    }

    private void Update()
    {
        if(successfulClick == false)
        {
            timer -= Time.deltaTime;
        }

        hitInfo.transform.localScale = new Vector3(timer, timer, timer);

        if(isGreen )
        {
            clickGreenTimer -= Time.deltaTime;
        }

        if(clickGreenTimer <= 0 )
        {
            isGreen = false;
        }

        if (timer > 0 )
        {
            whiteRect.color = Color.red;
        }
        else if(timer <= deathTime )
        {
            whiteRect.color = Color.red;
            isDead = true;
            Debug.Log("MOOOOORT");
        }

        if(isDead == false && timer <= 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                successfulClick = true;
                playerSwing = true;
                FindAngleMouse.Instance.ShootBullet();
                whiteRect.color = Color.red;
            }
        }

        StandartBullet();
        DownBullet();
        UpBullet();
    }


    enum BulletType
    {
        up,
        middle,
        down
    }

    /*public void CallCurrentBullet()
    {
        switch (currentBulletType)
        {
            case BulletType.up:

                StartCoroutine(UpBulletSpeed());
                Debug.Log("UUUUP");
                isCallingBullet = false;

                break;

            case BulletType.middle:

                StartCoroutine(StandartBulletSpeed());
                Debug.Log("MIIIIDDLE");
                isCallingBullet = false;

                break;

            case BulletType.down:

                StartCoroutine(DownBulletSpeed());
                Debug.Log("DOOOOOWN");
                isCallingBullet = false;

                break;
        }
    }*/


    public void CallBullet()
    {

        if (isCallingBullet == false && isDead == false && playerSwing == false)
        {
            //CallCurrentBullet();
            randomReactionSpeed = Random.Range(0, 3);
            if (randomReactionSpeed == 0)
            {
                currentBulletType = BulletType.middle;
                timer += startTimer * 2;
                successfulClick = false;

                Debug.Log("Standart Bullet Incoming");

            }
            else if (randomReactionSpeed == 1)
            {
                currentBulletType = BulletType.up;
                timer += startTimer * 3;
                successfulClick = false;

                Debug.Log("Up Bullet Incoming");

            }
            else if (randomReactionSpeed == 2)
            {
                currentBulletType = BulletType.down;
                timer += startTimer;
                successfulClick = false;

                Debug.Log("Down Bullet Incoming");

            }
        }
        isCallingBullet = true;
        //SetTimerAccordingToCurrentBullet();
    }

    /*void SetTimerAccordingToCurrentBullet()
    {
        switch (currentBulletType)
        {
            case BulletType.up:
                UpBullet();

                break;
            case BulletType.middle:
                StandartBullet();

                break;
            case BulletType.down:
                DownBullet();

                break;
        }
    }*/



    public void StandartBullet()
    {
        if(timer <= 0 && randomReactionSpeed == 0 && isDead == false)
        {
            clickGreenTimer = startGreenTimer;
            isGreen = true;
            whiteRect.color = Color.green;
        }
    }

    public void UpBullet()
    {
        if (timer <= 0 && randomReactionSpeed == 1 && isDead == false)
        {
            clickGreenTimer = startGreenTimer;
            isGreen = true;
            whiteRect.color = Color.green;
        }
    }

    public void DownBullet()
    {
        if (timer <= 0 && randomReactionSpeed == 2 && isDead == false)
        {
            clickGreenTimer = startGreenTimer;
            isGreen = true;
            whiteRect.color = Color.green;
        }
    }

    public void EnemySwing()
    {
        playerSwing = false;
        successfulClick = false;
        isCallingBullet = false;
    }
}
