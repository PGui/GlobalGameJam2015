using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour 
{

	public AudioClip [] clipDead;

	public bool isDead {get; set;}

	bool playOnceDeadSound = false;
	// Use this for initialization
	void Start () 
	{
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDead)
		{
			if(!playOnceDeadSound)
			{
				playOnceDeadSound= true;
				GetComponent<AudioSource>().PlayOneShot(clipDead[Random.Range(0,clipDead.Length)]);
			}

			collider2D.enabled = false;
			//transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;// transform.localScale.Set(0.5f,0.5f,0.0f);
			gameObject.rigidbody2D.velocity = Vector2.zero;
		}
		else 
		{
			if(collider2D.enabled == false)
			{
				playOnceDeadSound = false;
				collider2D.enabled = true;
				//transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
				//transform.GetChild(1).transform.localScale.Set(1.0f,1.0f,0.0f);
			}
			
		}
	}
}
