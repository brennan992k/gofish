using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public int Once;
    public int A;
    public GameObject Gold1;
    public GameObject Gold;
    public GameObject Gold2;
    public GameObject Gem;
    public GameObject G2;
    public bool Move;
    public GameObject Cam;
    // Use this for initialization
    void Start()
    {
        Cam = GameObject.Find("Main Camera");
        if (transform.position.x >= Cam.transform.position.x + 1f)
        {
            Move = true;
        }
        if (transform.position.x <= Cam.transform.position.x - 1)
        {
            Move = false;
        }
        Cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Move == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += new Vector3(1.5f * Time.deltaTime, 0, 0);
        }
        if (Move == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position -= new Vector3(1.5f * Time.deltaTime, 0, 0);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "End")
        {
            GameObject.Find("Manage").GetComponent<Manage>().Mouse = true;
            Destroy(gameObject);

        }
        if (coll.gameObject.tag == "Rake")
        {
            if (GameObject.Find("Rake").GetComponent<Rake>().Full == false) {
                if (Once == 0) {
                if (A == 1)
                {
                    Instantiate(Gold, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                if (A == 2)
                {
                    Instantiate(Gold2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                if (A == 3)
                {
                    Instantiate(Gold1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                if (A == 4)
                {
                    Instantiate(Gem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                if (A == 5)
                {
                    Instantiate(G2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                GetComponent<Animator>().SetInteger("Mouse", 1);
                    Once += 1;
                }
            }
        }

    }
}

