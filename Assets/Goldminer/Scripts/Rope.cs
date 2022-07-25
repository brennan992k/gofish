using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public bool up;
    //public float Speedup;
    public bool down;
    //public float Speeddown ;
    public float SPEED;
    public float STOP;
    public float HighSpeed;
    public float SD;
    public float SU;


    public bool Run;
    public bool Gold2;
    public bool Gold1;
    //public GameObject Pos1;
    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {



        if (GameObject.Find("Manage").GetComponent<Manage>().Lose == false)
        {
            if (Run == true && GameObject.Find("Manage").GetComponent<Manage>().Startgame == 1)
            {

                transform.localScale += new Vector3(0, 2.5f * Time.deltaTime, 0);
                if (transform.localScale.y >= 4.2f)
                {
                    Run = false;
                }
            }

            if (Run == false && GameObject.Find("Manage").GetComponent<Manage>().Startgame == 1 && Gold2 == false && Gold1 == false)
            {


                transform.localScale -= new Vector3(0, 2.5f * Time.deltaTime, 0);
                if (transform.localScale.y <= 1f)
                {
                    transform.localScale = new Vector3(1, 1f, 1);
                }
            }



            if (Run == false && GameObject.Find("Manage").GetComponent<Manage>().Startgame == 1&&Gold2==false && Gold1 == true)
            {


                transform.localScale -= new Vector3(0, 1.5f * Time.deltaTime, 0);
                if (transform.localScale.y <= 1f)
                {
                    transform.localScale = new Vector3(1, 1f, 1);
                }
            }
            if (Run == false && GameObject.Find("Manage").GetComponent<Manage>().Startgame == 1 && Gold2 == true && Gold1 == false)
            {


                transform.localScale -= new Vector3(0, 1f * Time.deltaTime, 0);
                if (transform.localScale.y <= 1f)
                {
                    transform.localScale = new Vector3(1, 1f, 1);
                }
            }
        }










      //  transform.position = Pos1.transform.position;


        if (transform.localScale.y <= 1f)
        {
            if (transform.eulerAngles.z >= 40 && transform.eulerAngles.z <= 60)
            {

                up = false;
                down = true;
            }
            if (transform.eulerAngles.z >= 310 && transform.eulerAngles.z <= 330)
            {

                up = true;
                down = false;
            }
            if (up == true)
            {
                SU += SPEED * Time.deltaTime;
                if (SU >= HighSpeed)
                {
                    SU = HighSpeed;
                }
                transform.eulerAngles += new Vector3(0, 0, SU * Time.deltaTime);
            }

            if (up == false)
            {
                SU -= STOP * Time.deltaTime;
                if (SU < 0)
                {
                    SU = 0;
                }
                transform.eulerAngles += new Vector3(0, 0, SU * Time.deltaTime);
            }
            ///////////////////////////////////////////////////////////////////////////////


            if (down == true)
            {
                SD += SPEED * Time.deltaTime;
                if (SD >= HighSpeed)
                {
                    SD = HighSpeed;
                }
                transform.eulerAngles -= new Vector3(0, 0, SD * Time.deltaTime);
            }

            if (down == false)
            {
                SD -= STOP * Time.deltaTime;
                if (SD <= 0)
                {
                    SD = 0;
                }
                transform.eulerAngles -= new Vector3(0, 0, SD * Time.deltaTime);
            }
        }
    }
}
