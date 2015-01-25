using UnityEngine;
using System.Collections;

public class fxdash : MonoBehaviour {

	Animator animationController;

	float time = 0.0f;
	public float Displaytime = 0.2f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(time >= Displaytime)
		{
			Destroy(gameObject);
		}

		time+=Time.deltaTime;
	}
}
