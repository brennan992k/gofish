using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
		GameObject rope = GameObject.Find("FishingRod");
		GameObject manage = GameObject.Find("Manage");

		FishingRodStatus status = rope.GetComponent<FishingRod>().Status;

		if(manage.GetComponent<Manage>().Startgame == 1)
        {
			switch (status)
			{
				case FishingRodStatus.None:
					if (rope.transform.localScale.y <= 1.02f)
					{
						rope.GetComponent<FishingRod>().Status = FishingRodStatus.Fishing;
					}
					break;
				case FishingRodStatus.Fishing:
					break;
				case FishingRodStatus.Catched:
					break;
			}
		}
    }
}
