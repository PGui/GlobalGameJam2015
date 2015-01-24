using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {


	public bool isDead {get; set;}
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
			collider2D.enabled = false;
		}
		else 
		{
			if(collider2D.enabled == false)
			{
				collider2D.enabled = true;
			}
			
		}
	}
}
