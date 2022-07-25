using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour {
    public GameObject Again;
    public GameObject[] M;
    public int num;
    public int BestScore;
    public bool End=false;
    public int Startgame;
    public int Score;
    public int Sound;
    public bool Mouse;
    public float X;
    public int RandomX;
    public GameObject Cut2;
    public GameObject Cut3;
    public GameObject Cut4;
    public bool Lose;

    public int Once;
    public bool S1;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Sound = PlayerPrefs.GetInt("Sound", Sound);
        BestScore = PlayerPrefs.GetInt("BestScore", BestScore);
        InvokeRepeating("Mouse1",1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Sound == 0&&S1==false)
        {
            GameObject.Find("Menu").GetComponent<AudioSource>().Play();
            S1 = true;
        }
        if (Sound == 1 && S1 == true)
        {
            GameObject.Find("Menu").GetComponent<AudioSource>().Stop();
            S1 = false;
        }
        if (Lose == true)
        {
            Once += 1;
            if (Once == 1)
            {

                Time.timeScale = 0.3f;
                StartCoroutine(E());
            }
        }
        if (Sound >= 2)
        {
            Sound = 0;
        }
        if (Score >= 10)
        {
            Cut2.SetActive(true);
        }
        if (Score >= 25)
        {
            Cut3.SetActive(true);
        }
        if (Score >= 40)
        {
            Cut4.SetActive(true);
        }
        if (Score >= 9999)
        {
            Score = 9999;
        }
        if (Score <= 0)
        {
            Score = 0;
        }

        if (Score >=BestScore)
        {
            BestScore = Score;
        }

        PlayerPrefs.SetInt("Sound", Sound);
       PlayerPrefs.SetInt("BestScore", BestScore);

    }



    void Mouse1()
    {
        RandomX = Random.Range(0, 2);
        if (RandomX == 0)
        {
            X = 4.4f;
        }
        if (RandomX ==1)
        {
            X = -4.4f;
        }
        num = Random.Range(0, 6);

        if (End == false) { 
        Instantiate(M[num], new Vector3(X, Random.Range(0,-6), transform.position.z), Quaternion.identity);
        }
    }
    IEnumerator E()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Again, new Vector3(0, 0,-3f), Quaternion.identity);
        Time.timeScale = 0;

    }
}

