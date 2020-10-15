using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkBehaviour : MonoBehaviour
{
    public LineRenderer trace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //create a new Trace prefab if chalk is used.
        //while chalk is used, add x, y, z points to the newly created Trace prefab 
        int k = 0;


        LineRenderer newTrace = Instantiate(trace, transform.position, transform.rotation);
        newTrace.positionCount++;
        newTrace.SetPosition(k, transform.position);
        k++;
    }
}
