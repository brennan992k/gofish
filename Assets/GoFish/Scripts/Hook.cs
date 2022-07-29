using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
    public GameObject FishingRod;

    void Start() {
        FishingRod = GameObject.Find("FishingRod");
    }

    // Update is called once per frame
    void Update() {
        transform.localScale = new Vector3(transform.localScale.x, 0.2f / FishingRod.transform.localScale.y, 1);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch(coll.gameObject.tag)
        {
            case "Fish":
                GameObject fish = coll.gameObject;

                if (FishingRod.GetComponent<FishingRod>().MaximumWeight > fish.GetComponent<Fish>().Weight)
                {
                    coll.gameObject.transform.Rotate(new Vector3(0, 0, fish.GetComponent<Fish>().FromRight ? -Random.Range(80, 90) : Random.Range(80, 90)));
                    fish.GetComponent<Fish>().status = FishStatus.IsCatched;
                    FishingRod.GetComponent<FishingRod>().Status = FishingRodStatus.Catched;
                }else
                {
                    FishingRod.GetComponent<FishingRod>().Status = FishingRodStatus.None;
                }
                break;
        }
    }
}
    
