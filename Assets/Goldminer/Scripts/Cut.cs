using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour {
    public bool Move;
    public GameObject Cam;
	// Use this for initialization
	void Start () {
		Cam= GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        if (Move == false) {
           // GetComponent<BoxCollider2D>().enabled = true;
           // GetComponent<CapsuleCollider2D>().enabled = false;
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += new Vector3(1.5f * Time.deltaTime, 0, 0);
        }
        if (Move == true)
        {
           // GetComponent<BoxCollider2D>().enabled = false;
          //  GetComponent<CapsuleCollider2D>().enabled = true;
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position -= new Vector3(1.5f * Time.deltaTime, 0, 0);
        }
        if (transform.position.x >= Cam.transform.position.x + 4.2f)
        {
            Move = true;
        }
        if (transform.position.x<= Cam.transform.position.x- 4.2f)
        {
            Move = false;
        }
    }
}
