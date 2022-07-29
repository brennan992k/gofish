using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStatus
{
    Fishing,
    IsCatched,
}

public class Fish : MonoBehaviour
{
    public bool BigFish = false;
    public int Score = 1;
    public int Skill = 1;
    public float Weight = 1;
    public float Speed = 1.5f;
    public bool FromRight = true;
    public bool Group = false;
    public FishStatus status = FishStatus.Fishing;

    GameObject Cam;

    void Start()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = FromRight ? Mathf.Abs(localScale.x): - Mathf.Abs(localScale.x);
        transform.localScale = localScale;

        GetComponent<Rigidbody2D>().mass = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        Cam = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case FishStatus.Fishing:
                if (BigFish)
                {
                    Vector3 localScale = transform.localScale;
                    if (transform.position.x >= Cam.transform.position.x + 9f)
                    {
                        localScale.x = Mathf.Abs(localScale.x);
                        transform.localScale = localScale;
                        FromRight = true;
                    }
                    if (transform.position.x <= Cam.transform.position.x - 9f)
                    {
                        localScale.x = -Mathf.Abs(localScale.x);
                        transform.localScale = localScale;
                        FromRight = false;
                    }
                }
                if (FromRight)
                {
                    transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                }
                break;
            case FishStatus.IsCatched:
                transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Hook").transform.position, 8f);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                break;

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject manage = GameObject.Find("Manage");

        switch(coll.gameObject.tag)
        {
            case "End":
                manage.GetComponent<Manage>().ShouldRenderFishes = true;
                Destroy(gameObject);
                break;
            case "Fish":
                manage.GetComponent<Manage>().ShouldRenderFishes = true;
                GameObject fish = coll.gameObject;
                if (fish.GetComponent<Fish>().Skill < Skill)
                {
                    Skill += fish.GetComponent<Fish>().Skill;
                    Destroy(fish);
                }
                break;
            case "Ok":
                if (manage.GetComponent<Manage>().Sound == 0)
                {
                    GameObject gold = GameObject.Find("GOLD");
                    gold.GetComponent<AudioSource>().Play();

                }
                manage.GetComponent<Manage>().Score += Score;
                //GameObject life = GameObject.Find("Life");
                //life.transform.localScale += new Vector3(5 * Time.deltaTime, 0, 0);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}

