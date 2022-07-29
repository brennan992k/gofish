using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {


    GameObject manage;

	// Use this for initialization
	void Start () {
        manage = GameObject.Find("Manage");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x >= 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (manage.GetComponent<Manage>().Startgame == 1)
        {
            transform.localScale -= new Vector3(0.02f * Time.deltaTime, 0, 0);

            if (transform.localScale.x <= 0)
            {
                transform.localScale = new Vector3(0, 1, 1);
                manage.GetComponent<Manage>().Lose = true;
            }
        }
	}
}
