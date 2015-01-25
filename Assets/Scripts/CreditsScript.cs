using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 4; ++i)
		{
			if (Input.GetButtonUp("P" + (i + 1).ToString() + " A"))
			{
				Application.LoadLevel("Menu");
			}
			
			if (Input.GetButton("P" + (i + 1).ToString() + " Start"))
			{
				Application.LoadLevel("Menu");
			}

			if (Input.GetButtonUp("P" + (i + 1).ToString() + " B"))
			{
				Application.LoadLevel("Menu");
			}

		}
	
	}
}
