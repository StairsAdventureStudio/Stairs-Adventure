using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEcho : MonoBehaviour {
   
    public float startTimeBtwSpawns=0.5f;
    public float timeToDed=1;

    public GameObject o;

    float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    void Update () {
		if(PlayerPrefs.GetInt("fade",1)==1)
        {
            if(timeBtwSpawns <= 0)
            {
                Destroy(Instantiate(o, transform.position, transform.rotation), timeToDed);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
	}
}
