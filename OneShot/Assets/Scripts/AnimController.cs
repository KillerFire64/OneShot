using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator animator;

    const string HIGH_ANIM = "High";
    const string LINEAR_ANIM = "Linear";
    const string LOW_ANIM = "Low";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger(HIGH_ANIM);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger(LINEAR_ANIM);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(LOW_ANIM);
        }
    }
}
