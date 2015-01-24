using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{

	//Player ID
	private int m_playerID = 0;

	//Speed
	private float speed = 0.0f;
	public float m_maxSpeed = 50.0f;

	//Acc
	public float m_accel = 1.5f;
	public float m_deaccel = 0.8f;

	public  bool m_hasControl  {get; set;}
	private Vector2 m_moveInput;


	// Use this for initialization
	void Start () 
	{
		//Init player ID
		m_playerID = GetComponent<PlayerID>().GetPlayerID();

		m_hasControl = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		if(m_hasControl)
		{
			m_moveInput = new Vector2(Input.GetAxis("P" + m_playerID.ToString() + " LHorizontal"), Input.GetAxis("P" + m_playerID.ToString() + " LVertical"));
			//m_moveInput.Normalize();
			Vector2 currentVel = rigidbody2D.velocity;
			//Si le player essai de bouger
			if(m_moveInput.SqrMagnitude() > 0.2)
			{
				speed = Mathf.Min( speed + m_accel, m_maxSpeed);
				currentVel = speed * m_moveInput;
			}
			else//Sinon il deccelere
			{
				currentVel *= m_deaccel;
			}
			rigidbody2D.velocity = currentVel;


		}
	}
}
