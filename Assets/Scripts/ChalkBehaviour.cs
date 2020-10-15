using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using VRTK;

public class ChalkBehaviour : MonoBehaviour
{
    public LineRenderer trace;
    public VRTK_ControllerEvents controller;
    private bool draw;
    private int pointCounter;
    private LineRenderer currentTrace;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        controller.TriggerReleased += OnTriggerReleased;
        currentTrace = Instantiate(trace);
        draw = false;
        pointCounter = 0;
        offset = new Vector3(transform.localScale.z / 2, 0, 0);
    }

    private void OnTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        if(controller.gripPressed)
        {
            draw = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //create a new Trace prefab if chalk is used.
        //while chalk is used, add x, y, z points to the newly created Trace prefab 
        if (controller.gripPressed && controller.triggerPressed)
        {
            if(draw == false)
            {
                pointCounter = 0;
                currentTrace = Instantiate(trace, transform.position, transform.rotation);
                currentTrace.positionCount = 1;
                currentTrace.SetPosition(0, transform.position - offset);
                draw = true;
            } else
            {
                pointCounter++;
                currentTrace.positionCount = pointCounter;
                currentTrace.SetPosition(pointCounter - 1, transform.position - offset);
            }
        }
    }
}
