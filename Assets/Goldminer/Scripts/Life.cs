using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x >= 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
            if (GameObject.Find("Manage").GetComponent<Manage>().Startgame == 1)
        {
            transform.localScale -= new Vector3(0.02f * Time.deltaTime, 0, 0);
            if (transform.localScale.x <= 0)
            {
                transform.localScale = new Vector3(0, 1, 1);
                GameObject.Find("Manage").GetComponent<Manage>().Lose = true;
            }
        }
	}
}
