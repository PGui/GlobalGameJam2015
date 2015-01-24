using UnityEngine;
using System.Collections;

public class Football : MonoBehaviour 
{
	public Sprite teamBlue;
	public Sprite teamRed;
	
	GameObject[] m_players;
	GameObject[] m_playersCpy;

	public string Phrase;

	GameObject [] Camps;

	public GameObject football;
	Vector2 footbalSpawnPosition;

	public float newSpeed = 20.0f;
	private float previousSpeed = 00.0f;

	Transform terrainTransform;

	public bool gameOver {get; set;}

	GameObject refFootbal;
	
	// Use this for initialization
	void OnEnable () 
	{
		gameOver = false;

		m_players = GameObject.FindGameObjectsWithTag("Player");
		m_playersCpy = m_players;

		terrainTransform = GameObject.Find("Terrrain").transform;

		//Display the camps
		foreach (Transform child in terrainTransform)
		{
			//child is your child transform
			if(child.gameObject.name == "Camp")
			{
				child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}

			if(child.gameObject.name == "FootballSpawner")
			{
				footbalSpawnPosition = child.position;
			}
		}

		if(m_players.Length == 2)
		{
			m_players[0].gameObject.layer = LayerMask.NameToLayer("red");
			foreach (Transform t in m_players[0].transform)
			{
				if(t.name == "Team")
				{
					t.GetComponent<SpriteRenderer>().enabled = true;
					t.GetComponent<SpriteRenderer>().sprite = teamRed;
				}
			}
			m_players[1].gameObject.layer = LayerMask.NameToLayer("blue");
			foreach (Transform t in m_players[1].transform)
			{
				if(t.name == "Team")
				{
					t.GetComponent<SpriteRenderer>().enabled = true;
					t.GetComponent<SpriteRenderer>().sprite = teamBlue;
				}
			}
		}
		else
		{
			int redLeft = 2;
			
			ArrayList numbers = new ArrayList(m_players.Length);
			for (int i = 0; i < m_players.Length; i++) {
				numbers.Add(i);
			}
			var randomNumbers = new int[m_players.Length];
			for (int i = 0; i < randomNumbers.Length; i++) 
			{
				var thisNumber = Random.Range(0, numbers.Count);
				if(redLeft > 0)
				{
					m_players[i].gameObject.layer = LayerMask.NameToLayer("red");
					foreach (Transform t in m_players[i].transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = true;
							t.GetComponent<SpriteRenderer>().sprite = teamRed;
						}
					}
					--redLeft;
				}
				else
				{
					m_players[i].gameObject.layer = LayerMask.NameToLayer("blue");
					if(m_players.Length == 3)
					{
						previousSpeed = m_players[i].GetComponent<Control>().m_maxSpeed;
						m_players[i].GetComponent<Control>().m_maxSpeed = newSpeed;
					}
					foreach (Transform t in m_players[i].transform)
					{
						if(t.name == "Team")
						{
							t.GetComponent<SpriteRenderer>().enabled = true;
							t.GetComponent<SpriteRenderer>().sprite = teamBlue;
						}
					}
				}
				numbers.RemoveAt(thisNumber);
			}
		}




		refFootbal = GameObject.Instantiate(football,footbalSpawnPosition,Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOver)
			this.enabled = false;
	}

	void OnDisable()
	{
		//Remove the teams
		foreach(GameObject p in m_players)
		{
			if(m_players.Length == 3)
			{
				if(p.gameObject.layer == LayerMask.NameToLayer("blue"))
				{
					p.GetComponent<Control>().m_maxSpeed = previousSpeed;
				}
			}
			if(p != null)
				p.gameObject.layer = LayerMask.NameToLayer("Default");

			foreach (Transform t in p.transform)
			{
				if(t.name == "Team")
				{
					t.GetComponent<SpriteRenderer>().enabled = false;
					t.GetComponent<SpriteRenderer>().sprite = teamRed;
				}
			}
		}

		foreach (Transform child in terrainTransform)
		{
			//child is your child transform
			if(child.gameObject.name == "Camp")
			{
				child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}

		transform.GetComponent<ObjectiveManager>().currentObjective = ObjectiveManager.eObjectives.NONE;
		transform.GetComponent<ObjectiveManager>().m_needDisplayTimesUp = true;
		Destroy(refFootbal);
	}
}
