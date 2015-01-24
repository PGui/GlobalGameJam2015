using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private GameObject[] m_players;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_players != null && m_players.Length > 0)
		{

			//Compute the average position
			Vector2 avgPos = new Vector2();
			foreach(GameObject p in m_players)
			{
				avgPos.x += p.transform.position.x;
				avgPos.y += p.transform.position.y;
			}
			avgPos /= m_players.Length;
			this.transform.position = avgPos;
		}
		else
		{
			m_players = GameObject.FindGameObjectsWithTag("Player");
		}

	}
}
