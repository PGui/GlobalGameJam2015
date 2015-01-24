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

	private bool m_isDashing {get; set;}
	public float dashTime = 1.0f;
	public float m_forceDash = 500.0f;
	private float timeElapsedDash = 0.0f;
	private Vector2 m_dashDirection;

	// Use this for initialization
	void Start () 
	{
		//Init player ID
		m_playerID = GetComponent<PlayerID>().GetPlayerID();

		m_hasControl = false;

		m_isDashing = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("P" + m_playerID.ToString() + " A") && !m_isDashing)
		{
			m_isDashing = true;
			timeElapsedDash = 0.0f;
			m_dashDirection = m_moveInput;
			m_dashDirection.Normalize();
			//rigidbody2D.velocity = Vector2.zero;
			//Debug.Log("---Dashing---");
		}
	}

	void FixedUpdate()
	{
		if(m_hasControl)
		{
			//Get the stick input
			m_moveInput = new Vector2(Input.GetAxis("P" + m_playerID.ToString() + " LHorizontal"), Input.GetAxis("P" + m_playerID.ToString() + " LVertical"));

			//Dash



			//Si le player bouge
			if(m_moveInput.SqrMagnitude() > 0.2f && !m_isDashing)
			{
				speed = Mathf.Min( speed + m_accel, m_maxSpeed);
				rigidbody2D.velocity = speed * m_moveInput;
			}
			else if(!m_isDashing)//Sinon il deccelere
			{
				rigidbody2D.velocity *= m_deaccel;
			}

			//Si le joueur dash
			if(m_isDashing)
			{
				//rigidbody2D.velocity = m_dashDirection*
				rigidbody2D.AddForce(m_dashDirection*m_forceDash,ForceMode2D.Force);
			}

			//applyThe good velocity
			//rigidbody2D.velocity = currentVel;

			//Si on est en train de dasher
			if(m_isDashing && (timeElapsedDash > dashTime))
			{
				m_isDashing = false;
				//Debug.Log("You can dash again");
			}
			else if(m_isDashing)
			{
				timeElapsedDash += Time.deltaTime;
			}
			

		}


	}
}
