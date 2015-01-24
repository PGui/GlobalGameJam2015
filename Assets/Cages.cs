using UnityEngine;
using System.Collections;

public class Cages : MonoBehaviour 
{
	Football spFootball;
	public bool enterOnce {get; set;} 

	GameObject[] m_players;

	// Use this for initialization
	void Start () 
	{
		enterOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
		spFootball = GameObject.Find("ObjectiveManager").GetComponent<Football>();
		m_players = GameObject.FindGameObjectsWithTag("Player");
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(!enterOnce && other.gameObject.tag == "football")
		{
			enterOnce = true;
			Debug.Log("Goal");
			if(gameObject.tag == "campRouge")
			{
				foreach(GameObject p in m_players)
				{
					if(p.gameObject.layer == LayerMask.NameToLayer("blue"))
					{
						if(m_players.Length == 3)
							p.GetComponent<PlayerScore>().AddScore(2000);
						else
							p.GetComponent<PlayerScore>().AddScore(1000);
					}
				}
			}
			else//l'equipe rouge a gagné
			{
				foreach(GameObject p in m_players)
				{
					if(p.gameObject.layer == LayerMask.NameToLayer("red"))
					{
						p.GetComponent<PlayerScore>().AddScore(1000);
					}
				}
			}


			spFootball.gameOver = true;
		}
	}
}
