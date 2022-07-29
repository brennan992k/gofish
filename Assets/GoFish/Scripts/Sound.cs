using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public GameObject M;
    public GameObject S;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
        {
            M.SetActive(false);
            S.SetActive(true);
        }
        if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 1)
        {
            M.SetActive(true);
            S.SetActive(false);
        }

    }
   void OnMouseDown()
    {
        GameObject.Find("Manage").GetComponent<Manage>().Sound += 1;
    }
}
