using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour 
{

	PlayerScore score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("mouse"))
		{
			Debug.Log("Collision");
			coll.gameObject.GetComponent<Dead>().isDead = true;
			GetComponent<PlayerScore>().AddScore(1000);
		}
	}
}
