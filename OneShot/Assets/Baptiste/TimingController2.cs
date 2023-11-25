using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingController2 : MonoBehaviour
{
    public SpriteRenderer whiteRect;
    public GameObject hitInfo;

    public int randomReactionSpeed;
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
    public bool isMenu;
    public bool isFirstShot;
    public bool isFirstShot2;

    public GameObject DecaledBeatObject;
    public GameObject BeatObject;

    public FollowSplineHighReverse followSplineHighReverse;
    public FollowSplineLinearReverse followSplineLinearReverse;
    public FollowSplineLowReverse followSplineLowReverse;

    public static TimingController2 Instance;

    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isDead = false;
        playerSwing = true;
        successfulClick = true;
        isCallingBullet = true;
        isMenu = true;
        isFirstShot = true;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Return))
        {
            isMenu = false;
            StartShot();
        }

        if (successfulClick == false && isMenu == false)
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
            if(Input.GetKeyDown(KeyCode.E) && successfulClick == false)
            {
                successfulClick = true;
                playerSwing = true;
                FindAngleMouse.Instance.ShootDownBullet();
                whiteRect.color = Color.red;
            }
            else if (Input.GetKeyDown(KeyCode.R) && successfulClick == false)
            {
                successfulClick = true;
                playerSwing = true;
                FindAngleMouse.Instance.ShootStandartBullet();
                whiteRect.color = Color.red;
            }
            else if (Input.GetKeyDown(KeyCode.T) && successfulClick == false)
            {
                successfulClick = true;
                playerSwing = true;
                FindAngleMouse.Instance.ShootUpBullet();
                whiteRect.color = Color.red;
            }
        }

        if(isDead)
        {
            //Rajouter effets de la mort
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


    public void CallBullet()
    {

        if (isCallingBullet == false && isDead == false && playerSwing == false)
        {
            randomReactionSpeed = Random.Range(0, 3);
            if (randomReactionSpeed == 0)
            {
                timer += startTimer*2;
                successfulClick = false;
                followSplineLinearReverse.StartTravel();

                Debug.Log("Standart Bullet Incoming");

            }
            else if (randomReactionSpeed == 1)
            {
                timer += startTimer * 4;
                successfulClick = false;
                followSplineHighReverse.StartTravel();

                Debug.Log("Up Bullet Incoming");

            }
            else if (randomReactionSpeed == 2)
            {
                timer += startTimer;
                successfulClick = false;
                followSplineLowReverse.StartTravel();

                Debug.Log("Down Bullet Incoming");

            }
        }
        isCallingBullet = true;
    }



    public void StandartBullet()
    {
        if(timer <= 0 && randomReactionSpeed == 0 && isDead == false) //rajouter condition d'obstacle
        {
            clickGreenTimer = startGreenTimer;
            isGreen = true;
            whiteRect.color = Color.green;
        }
    }

    public void UpBullet()
    {
        if (timer <= 0 && randomReactionSpeed == 1 && isDead == false) //rajouter condition d'obstacle
        {
            clickGreenTimer = startGreenTimer;
            isGreen = true;
            whiteRect.color = Color.green;
        }
    }

    public void DownBullet()
    {
        if (timer <= 0 && randomReactionSpeed == 2 && isDead == false) //rajouter condition d'obstacle
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

        //rajouter animation de tir ennemi
    }

    public void StartShot()
    {
        DecaledBeatObject.SetActive(true);
        BeatObject.SetActive(true);
        playerSwing = false;
        successfulClick = false;
        audioSource.Play();
    }

    public void SetOnBeat()
    {
        if(isFirstShot)
        {
            if(isFirstShot2)
            {
                timer = startTimer * 2 - 0.05f;
                isFirstShot = false;
                isFirstShot2 = false;
            }
            isFirstShot2 = true;
        }
    }
}
