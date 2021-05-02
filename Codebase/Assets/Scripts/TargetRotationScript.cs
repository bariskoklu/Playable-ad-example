using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotationScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private List<ForceClass> forces;
    [Tooltip("Run the forces array once or loop it")]
    [SerializeField]
    private bool loop = false;

    private float timePassed = 0.0f;
    [SerializeField]
    private int currentListObjectIndex = 0;

    private bool anyForcesRemaining = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManagerScript.Instance.currentGameState == GameState.Playing)
        {
            if (anyForcesRemaining)
            {
                UpdateTime();
                CheckForForces();
            }
        }
        else
        {
            rb.angularVelocity = 0.0f;
        }
        
    }

    private void UpdateTime()
    {
        timePassed += Time.deltaTime;
    }

    private void CheckForForces()
    {
        ForceClass currentListObject = forces[currentListObjectIndex];
        if (currentListObject.timeToApply < timePassed)
        {
            //This adds rotating force to the target object, at specific time and magnitude.
            rb.AddTorque(currentListObject.forceMagnitude * (int)currentListObject.forceDirection, ForceMode2D.Impulse);
            JumpToNextElementofList();
        }
    }

    private void JumpToNextElementofList()
    {
        if (currentListObjectIndex == forces.Count -1)
        {
            if (loop)
            {
                currentListObjectIndex = 0;
                timePassed = 0.0f;
            }
            else
            {
                anyForcesRemaining = false;
            }
        }
        else
        {
            currentListObjectIndex++;
        }
    }
}
