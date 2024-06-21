using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    Movement movement;

    bool driftMarksFlag;

    public TrailRenderer[] driftMarks;
    public ParticleSystem[] particleSmoke;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    private void checkDrift()
    {
        if(movement.isDrifting == true)
        {
            StartVFX();
        }

        else
        {
            StopVFX();
        }
    }

    private void StopVFX()
    {
        if (!driftMarksFlag) return;
        foreach (TrailRenderer T in driftMarks)
        {
            T.emitting = false;
        }

        driftMarksFlag = false;
    }

    private void StartVFX()
    {
        if(driftMarksFlag) return;
        foreach (TrailRenderer T in driftMarks)
        {
            T.emitting = true;
        }

        driftMarksFlag = true;
    }
}
