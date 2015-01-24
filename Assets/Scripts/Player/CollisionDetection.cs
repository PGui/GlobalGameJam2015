using UnityEngine;
using System.Collections;

public class collisionDetection : MonoBehaviour 
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

			coll.gameObject.GetComponent<Dead>().isDead = true;
		}
	}
}
