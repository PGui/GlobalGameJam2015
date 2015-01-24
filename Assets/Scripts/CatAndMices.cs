	using UnityEngine;
	using System.Collections;

	public class CatAndMices : MonoBehaviour 
	{

		public float m_Duration = 30.0f;
		float m_time = 0.0f;

		public Sprite teamBlue;
		public Sprite teamRed;

		GameObject[] m_players;
		GameObject m_cat;

		public float m_NewCatSpeed = 15.0f;
		private float m_previousSpeed = 0.0f;

		public string Phrase;

		// Use this for initialization
		void OnEnable () 
		{
			
			m_time = 0.0f;

			m_players = GameObject.FindGameObjectsWithTag("Player");

			m_cat = m_players[Random.Range(0,m_players.Length)];
			//Init the cat (don't forget to desinit !!!!)
			m_previousSpeed = m_cat.GetComponent<Control>().m_maxSpeed;
			m_cat.GetComponent<Control>().m_maxSpeed = m_NewCatSpeed;
			m_cat.GetComponent<Control>().m_canDash = false;

			foreach(GameObject p in m_players)
			{
				
				if(p == m_cat)
				{
					p.gameObject.layer = LayerMask.NameToLayer("cat");
					foreach (Transform t in p.transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = true;
							t.GetComponent<SpriteRenderer>().sprite = teamRed;
						}
					}
				}
				else//C'est les souris
				{
				p.gameObject.layer = LayerMask.NameToLayer("mouse");
					foreach (Transform t in p.transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = true;
							t.GetComponent<SpriteRenderer>().sprite = teamBlue;
						}
					}
				}
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
		
			m_time+= Time.deltaTime;
			if(m_time >= m_Duration)
			{
				this.enabled = false;
			}
		}

		void OnDisable () 
		{
			if(m_cat != null)
			{
				m_cat.GetComponent<Control>().m_maxSpeed = m_previousSpeed ;
				m_cat.GetComponent<Control>().m_canDash = true;
			

			foreach(GameObject p in m_players)
			{
				p.gameObject.layer = 0;
				if(p == m_cat)
				{
					foreach (Transform t in p.transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = false;
							//t.GetComponent<SpriteRenderer>().sprite = teamRed;
						}
					}
				}
				else//C'est les souris
				{
					foreach (Transform t in p.transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = false;
							//t.GetComponent<SpriteRenderer>().sprite = teamBlue;
						}
					}
				}
			}//foreach



			transform.GetComponent<ObjectiveManager>().currentObjective = ObjectiveManager.eObjectives.NONE;
			transform.GetComponent<ObjectiveManager>().m_needDisplayTimesUp = true;



			}
		}
	}
