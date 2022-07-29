using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishingRodStatus
{
    None,
    Fishing,
    Catched,
}

public class FishingRod : MonoBehaviour {
    public float FishingSpeed = 1f;
    public float AngelSpeed = 50;
    public float MaximumAngelSpeed = 60;
    public float MaximumWeight = 10;
    public FishingRodStatus Status = FishingRodStatus.None;

    private float SD = 0;
    private float SU = 0;
    private bool Up = true;
    private bool Down = false;

    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        GameObject manage = GameObject.Find("Manage");

        if (manage.GetComponent<Manage>().Lose == false)
        {
            if(manage.GetComponent<Manage>().Startgame == 1)
            {
                switch(Status)
                {
                    case FishingRodStatus.None:
                        if (transform.localScale.y >= 1f) transform.localScale -= new Vector3(0, FishingSpeed * Time.deltaTime, 0);
                        break;
                    case FishingRodStatus.Fishing:
                        transform.localScale += new Vector3(0, FishingSpeed * Time.deltaTime, 0);
                        if (transform.localScale.y >= 5f) Status = FishingRodStatus.None;
                        break;
                    case FishingRodStatus.Catched:
                        /// caculate total weight of fishes is fished
                        /// caculate speed
                        transform.localScale -= new Vector3(0, FishingSpeed * Time.deltaTime, 0);
                        if (transform.localScale.y <= 1f)
                        {
                            transform.localScale = new Vector3(1, 1f, 1);
                            Status = FishingRodStatus.None;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        if (transform.localScale.y <= 1f)
        {
            if (transform.eulerAngles.z >= 40 && transform.eulerAngles.z <= 60)
            {

                Up = false;
                Down = true;
            }

            if (transform.eulerAngles.z >= 310 && transform.eulerAngles.z <= 330)
            {

                Up = true;
                Down = false;
            }

            if (Up == true)
            {
                SU += AngelSpeed * Time.deltaTime;
                SU = SU >= MaximumAngelSpeed ? MaximumAngelSpeed : SU;
                transform.eulerAngles += new Vector3(0, 0, SU * Time.deltaTime);
            }else
            {
                SU -= AngelSpeed * Time.deltaTime;
                SU = SU < 0 ? 0 : SU;
                transform.eulerAngles += new Vector3(0, 0, SU * Time.deltaTime);
            }

            if (Down == true)
            {
                SD += AngelSpeed * Time.deltaTime;
                SD = SD >= MaximumAngelSpeed ? MaximumAngelSpeed : SD;
                transform.eulerAngles -= new Vector3(0, 0, SD * Time.deltaTime);
            }else
            {
                SD -= AngelSpeed * Time.deltaTime;
                SD = SD < 0 ? 0: SD;
                transform.eulerAngles -= new Vector3(0, 0, SD * Time.deltaTime);
            }
        }
    }
}
