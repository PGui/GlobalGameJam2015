using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	Animator controller;

	GameObject player;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Animator>();
		player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		controller.SetFloat("speed",player.rigidbody2D.velocity.magnitude);
		controller.SetBool("dashing",player.GetComponent<Control>().m_isDashing);
	}
}
