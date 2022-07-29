using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour {
    public GameObject PlayAgain;
    public GameObject[] Fishes;
    public GameObject[] Clouds;

    public bool ShouldRenderFishes;
    public bool ShouldRenderClouds;

    public int BestScore;
    public bool End = false;
    public int Startgame;
    public int Score;
    public int Sound;
    public bool Mouse;
    public float X;
    public int RandomX;
    public bool Lose;

    public int Once;
    public bool S1;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Sound = PlayerPrefs.GetInt("Sound", Sound);
        BestScore = PlayerPrefs.GetInt("BestScore", BestScore);
        InvokeRepeating("RenderFishes", 1f, 1f);
        InvokeRepeating("RenderClouds", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject menu = GameObject.Find("Menu");
        if (Sound == 0 && S1 == false)
        {
            menu.GetComponent<AudioSource>().Play();
            S1 = true;
        }
        if (Sound == 1 && S1 == true)
        {
            menu.GetComponent<AudioSource>().Stop();
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

        if (Score >= BestScore)
        {
            BestScore = Score;
        }

        PlayerPrefs.SetInt("Sound", Sound);
        PlayerPrefs.SetInt("BestScore", BestScore);

    }

    void RenderFishes()
    {
        if (Fishes.Length < 1 || !ShouldRenderFishes) return;

        int num = Random.Range(0, Fishes.Length);

        if (!End)
        {
            GameObject fish = Fishes[num];
            GameObject ok = GameObject.Find("Ok");
            GameObject stones = GameObject.Find("Stones");
            GameObject endLeft = GameObject.Find("EndLeft");
            GameObject endRight = GameObject.Find("EndRight");

            Vector3 posititon = fish.transform.position;
            Vector3 localScale = fish.transform.localScale;

            posititon.y = Random.Range(stones.transform.position.y + 2.5f, ok.transform.position.y - 2.5f);

            int random = Random.Range(-2, 2);
            bool fromRight = random > -1;
            if (fromRight) // right
            {
                localScale.x = Mathf.Abs(localScale.x);
                posititon.x = endRight.transform.position.x - 2f;
            }else // left
            {
                localScale.x = - Mathf.Abs(localScale.x);
                posititon.x = endLeft.transform.position.x + 2f;
            }

            fish.transform.position = posititon;
            fish.GetComponent<Fish>().FromRight = fromRight; // right if true

            if (fish.GetComponent<Fish>().Group)
            {
                int num2 = Random.Range(0, 6);
                float alpha = Random.Range(1f, 1.5f);
                Vector3 position = fish.transform.position;

                for (int i = 0; i < num2; i ++)
                {
                    float alpha2 = Random.Range(0, 0.85f);

                    if (i == 1)
                    {
                        position.x = position.x + alpha + alpha2;
                        position.y = position.y + (alpha + alpha2) / 2;
                    }
                    if(i == 2)
                    {
                        posititon.x = position.x - alpha - alpha2;
                        posititon.y = position.y - (alpha + alpha2) / 2;
                    }
                    if (i == 3)
                    {
                        posititon.y = position.y + (alpha + alpha2) / 2;
                        posititon.x = position.x + alpha / 2;
                    }
                    if (i == 4)
                    {
                        posititon.y = position.y - (alpha + alpha2) / 2;
                        posititon.x = position.x - alpha;
                    }
                    if (i == 5)
                    {
                        posititon.x = position.x + alpha / 2;
                        position.y = position.y + (alpha + alpha2) / 2;
                    }
                    if (i == 6)
                    {
                        posititon.x = position.x - alpha / 2;
                        position.y = position.y - alpha / 2;
                    }

                    fish.transform.position = position;
                    Instantiate(fish);
                }
            }
            else
            {
                Instantiate(fish);
            }

            ShouldRenderFishes = false;
        }
    }

    void RenderClouds()
    {
        if (Clouds.Length < 1 || !ShouldRenderClouds) return;

        int num = Random.Range(0, Clouds.Length);
        
        if (End == false)
        {
            // Play from Left
            GameObject fisherMan = GameObject.Find("FisherMan");
            GameObject endLeft = GameObject.Find("EndLeft");
            GameObject cloud = Clouds[num];

            Vector3 posititon = cloud.transform.position;
            posititon.y = Random.Range(fisherMan.transform.position.y + 3f, fisherMan.transform.position.y + 3.5f);
            posititon.x = endLeft.transform.position.x + 2f;
            cloud.transform.position = posititon;

            Instantiate(cloud);
            ShouldRenderClouds = false;
        }
    }

    IEnumerator E()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(PlayAgain, new Vector3(0, 0,-3f), Quaternion.identity);
        Time.timeScale = 0;

    }
}

