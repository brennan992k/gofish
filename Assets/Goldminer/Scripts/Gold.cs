using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject Rake;
    public int A;
    public bool Cut;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().mass = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Rake = GameObject.Find("Rake");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -8f)
        {
            Destroy(gameObject);
        }
        if (Cut == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Rake.transform.position, 8f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        }
        if (Cut == true)
        {
            GetComponent<Rigidbody2D>().mass = 0.7f;
            GetComponent<Rigidbody2D>().gravityScale = 0.7f;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Cut")
        {
            if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
            {
                GameObject.Find("EAT").GetComponent<AudioSource>().Play();

            }
            Cut = true;
        }
        if (coll.gameObject.tag == "Ok")
        {
            if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
            {
                GameObject.Find("GOLD").GetComponent<AudioSource>().Play();
              
            }
            GameObject.Find("Manage").GetComponent<Manage>().Score += A;
            GameObject.Find("Life").transform.localScale += new Vector3(5 * Time.deltaTime, 0, 0);
           Destroy(gameObject);
        }
    }
}
