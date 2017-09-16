using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondPulse : MonoBehaviour {

    private UpdateScroll line;

	// Use this for initialization
	void Start () {
        line = GetComponent<UpdateScroll>();
        StartCoroutine("makePulse", 1.0f);
	}

    IEnumerator makePulse(float time)
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            line.AddPoint(10000000.0f);
        }
    }
	
}
