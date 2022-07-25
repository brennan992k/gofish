using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : MonoBehaviour {
    //   public GameObject Target;
    public GameObject Rope;
    public bool Full;
    // Use this for initialization
    void Start() {
        Rope = GameObject.Find("Rope");
    }

    // Update is called once per frame
    void Update() {
        transform.localScale = new Vector3(1, 1 / Rope.transform.localScale.y, 1);
        //Target = GameObject.Find("Pos1");
        //transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 6f);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
       if (Full == false) { 
        if (coll.gameObject.tag == "Gold" || coll.gameObject.tag == "Gem" )
        {
            GameObject.Find("Rope").GetComponent<Rope>().Gold1 = true;
            GameObject.Find("Rope").GetComponent<Rope>().Run = false;
            Full = true;
        }
        if ( coll.gameObject.tag == "Gold2")
        {
            GameObject.Find("Rope").GetComponent<Rope>().Gold2 = true;
            GameObject.Find("Rope").GetComponent<Rope>().Run = false;
            Full = true;
        }
        }
        if (coll.gameObject.tag == "Cut")
        {
            if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
            {
                if(GameObject.Find("Rope").GetComponent<Rope>().Run == true) { 
                GetComponent<AudioSource>().Play();
                }
            }
                GameObject.Find("Rope").GetComponent<Rope>().Run = false;
            GameObject.Find("Rope").GetComponent<Rope>().Gold2 = false;
            GameObject.Find("Rope").GetComponent<Rope>().Gold1 = false;
        }
        }
    void OnTriggerExit2D(Collider2D coll)
    {
        GameObject.Find("Rope").GetComponent<Rope>().Gold2 = false;
        GameObject.Find("Rope").GetComponent<Rope>().Gold1 = false;
        Full = false;
        

    }

}
    
