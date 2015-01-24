using UnityEngine;
using System.Collections;

public class BallMng : MonoBehaviour {

	Vector2 direction;
	public float speed {get; set;}

	// Use this for initialization
	void Start () 
	{
		direction = new Vector2(Random.Range(0,100), Random.Range(0,100));
		direction.Normalize();
		rigidbody2D.AddForce(new Vector2( 1,1));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(rigidbody2D.velocity.magnitude < speed)
			rigidbody2D.AddForce(500 * rigidbody2D.velocity.normalized);
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		//Cat and mices
		if (coll.gameObject.layer == LayerMask.NameToLayer("wall"))
		{

			direction = new Vector2(Random.Range(0,100), Random.Range(0,100));
			direction.Normalize();
			rigidbody2D.AddForce(500 * direction);
		}

		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<Dead>().isDead = true;
			coll.gameObject.rigidbody2D.velocity = Vector2.zero;
		}
	}
}
