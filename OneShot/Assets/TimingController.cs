using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimingController : MonoBehaviour
{
    private bool clockIsTicking;
    private bool timerCanBeStopped;
    private float reactionTime;
    private float startTime;
    private float randomReactionSpeed;

    public float delayBeforeGameOver;

    public float startClickTimer;
    public float clickTimer;

    public bool isGameOver;

    public SpriteRenderer whiteRect;
    public Intervals intervals;

    private void Start()
    {
        reactionTime = 0f;
        startTime = 0f;
        clockIsTicking = false;
        timerCanBeStopped = true;
    }

    private void Update()
    {
        clickTimer -= Time.deltaTime;
        timer -= Time.deltaTime;

        if (delayBeforeGameOver < 0)
        {
            whiteRect.color = Color.red;
            Debug.Log("Game Over");
            isGameOver = true;
            clockIsTicking = false;
            StopAllCoroutines();
        }

        if(timerCanBeStopped == true)
        {
            delayBeforeGameOver -= Time.deltaTime;
        }


        if (clickTimer > 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!clockIsTicking)
                {
                    Debug.Log("1er if");
                    whiteRect.color = Color.red;
                    clockIsTicking = true;
                    timerCanBeStopped = false;
                }
                else if (clockIsTicking && timerCanBeStopped)
                {
                    Debug.Log("2eme if, le bon !");
                    reactionTime = Time.time - startTime;
                    delayBeforeGameOver = 10f;
                    clockIsTicking = false;
                    whiteRect.color = Color.red;
                    clockIsTicking = true;
                    timerCanBeStopped = false;
                }
                else if (clockIsTicking && !timerCanBeStopped)
                {
                    Debug.Log("3eme if");
                    reactionTime = 0f;
                    clockIsTicking = false;
                    timerCanBeStopped = true;

                }
                Debug.Log("Nice Timing");
            }
            
        }
    }

    BulletType currentBulletType;

    enum BulletType
    {
        up,
        middle,
        down
    }

    public void CallCurrentBullet()
    {
        switch(currentBulletType)
        {
            case BulletType.up:
                
                StartCoroutine(UpBulletSpeed());
                Debug.Log("UUUUP");
                break;
            case BulletType.middle:
                StartCoroutine(StandartBulletSpeed());
                Debug.Log("MIIIIDDLE");
                break;
            case BulletType.down:
                StartCoroutine(DownBulletSpeed());
                Debug.Log("DOOOOOWN");
                break;
        }
    }

    public float timer;
    public void CallBullet()
    {
        if(timer <= 0f && isGameOver == false)
        {
            CallCurrentBullet();
            randomReactionSpeed = Random.Range(0, 3);
            if (randomReactionSpeed == 0)
            {
                currentBulletType = BulletType.middle;
                Debug.Log("Standart Bullet Incoming");

            }
            else if (randomReactionSpeed == 1)
            {
                currentBulletType = BulletType.up;
                Debug.Log("Up Bullet Incoming");

            }
            else if (randomReactionSpeed == 2)
            {
                currentBulletType = BulletType.down;
                Debug.Log("Down Bullet Incoming");

            }

            SetTimerAccordingToCurrentBullet();
        }
    }

    void SetTimerAccordingToCurrentBullet()
    {
        switch (currentBulletType)
        {
            case BulletType.up:
                timer = clickTimer;

                break;
            case BulletType.middle:
                timer = clickTimer * 2f;

                break;
            case BulletType.down:
                timer = clickTimer * 3f;

                break;
        }
    }

    public void CanPlayerClick()
    {
        clickTimer = startClickTimer;
        Debug.Log("Timer Restarts !");
    }

    private IEnumerator StandartBulletSpeed()
    {
        delayBeforeGameOver = clickTimer;
        whiteRect.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
        if (delayBeforeGameOver < 0)
        {
            whiteRect.color = Color.red;
            Debug.Log("Game Over");
            isGameOver = true;
            clockIsTicking = false;
            StopAllCoroutines();
        }

        yield return new WaitForSeconds(clickTimer);
    }

    private IEnumerator UpBulletSpeed()
    {
        delayBeforeGameOver = clickTimer;
        whiteRect.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
        if (delayBeforeGameOver < 0)
        {
            whiteRect.color = Color.red;
            Debug.Log("Game Over");
            isGameOver = true;
            clockIsTicking = false;
            StopAllCoroutines();
        }

        yield return new WaitForSeconds(clickTimer);


    }

    private IEnumerator DownBulletSpeed()
    {
        delayBeforeGameOver = clickTimer;
        whiteRect.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
        if (delayBeforeGameOver < 0)
        {
            whiteRect.color = Color.red;
            Debug.Log("Game Over");
            isGameOver = true;
            clockIsTicking = false;
            StopAllCoroutines();
        }

        yield return new WaitForSeconds(clickTimer);
    }
}
