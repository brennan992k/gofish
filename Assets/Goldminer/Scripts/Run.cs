using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        if(GameObject.Find("Rope").GetComponent<Rope>().Run == false&& GameObject.Find("Rope").transform.localScale.y<=1.02f && GameObject.Find("Manage").GetComponent<Manage>().Startgame==1)
        {
            GameObject.Find("Rope").GetComponent<Rope>().Run = true;
        }
    }
}
