using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private GameObject[] m_players;

	public float cameraSpeed = 10.0f;

	Vector2 previousAvgPoint;

	// Use this for initialization
	void Start () {
		previousAvgPoint = Vector2.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
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


			Vector2 CamToAvgPoint = new Vector2 (avgPos.x - this.transform.position.x, avgPos.y - this.transform.position.y );
			float distance = CamToAvgPoint.magnitude;
			if(CamToAvgPoint.magnitude > 0.1 && avgPos != previousAvgPoint)
			{
				CamToAvgPoint.Normalize();
				rigidbody2D.velocity = CamToAvgPoint * cameraSpeed * distance;
			}
			else
			{
				rigidbody2D.velocity *= 0.3f;
			}

			previousAvgPoint = avgPos;
			//this.transform.position = avgPos;
		}
		else
		{
			m_players = GameObject.FindGameObjectsWithTag("Player");
		}

	}
}
