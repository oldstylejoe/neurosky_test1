using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpdateScroll : MonoBehaviour {

    private int NPoints;

    private Vector3[] data;
    private LineRenderer line;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        NPoints = line.positionCount;
        data = new Vector3[NPoints];

		for(int i = 0; i < NPoints; ++i) 
        {
            data[i].x = (float)i / (float)NPoints;
            data[i].y = 0.0f;
            data[i].z = 1.0f;
            line.SetPositions(data);
        }
	}

    //this is a lot of copying that could be improved.
    public void AddPoint(float x, float y)
    {
        for (int i = 1; i < NPoints; ++i)
        {
            data[i - 1] = data[i];
        }
        data[NPoints - 1].x = x;
        data[NPoints - 1].y = y;
        line.SetPositions(data);
    }
    public void AddPoint(float y)
    {
        for (int i = 1; i < NPoints; ++i)
        {
            data[i - 1].y = data[i].y;
        }
        data[NPoints - 1].y = y;
        line.SetPositions(data);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
