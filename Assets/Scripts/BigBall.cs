using UnityEngine;
using System.Collections;

public class BigBall : MonoBehaviour {

	// Use this for initialization

	public float m_Duration = 30.0f;
	float m_time = 0.0f;

	public GameObject ball;
	public float ballSpeed = 25.0f;

	public string Phrase;

	GameObject Theball;

	GameObject[] m_players;

	void OnEnable () 
	{
		Sprite terrainSprite = GameObject.Find("Terrrain").GetComponent<SpriteRenderer>().sprite;

		Vector2 posBall = new Vector2(Random.Range(terrainSprite.bounds.min.x + 5, terrainSprite.bounds.max.x -5),
		                              Random.Range(terrainSprite.bounds.min.y + 5, terrainSprite.bounds.max.y -5));

		//Ball spawn
		Theball = GameObject.Instantiate(ball,posBall,Quaternion.identity) as GameObject ;
		Theball.GetComponent<BallMng>().speed = ballSpeed;

		m_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_time+= Time.deltaTime;
		if(m_time >= m_Duration)
		{
			this.enabled = false;
		}

		if(EveryBodyDead())
			this.enabled = false;
	}

	void OnDisable()
	{
		m_time = 0.0f;
		transform.GetComponent<ObjectiveManager>().currentObjective = ObjectiveManager.eObjectives.NONE;
		transform.GetComponent<ObjectiveManager>().m_needDisplayTimesUp = true;
		Destroy(Theball);

		//Give points to the players alive
		foreach(GameObject p in m_players)
		{


			if(!p.gameObject.GetComponent<Dead>().isDead)
			{
				p.GetComponent<PlayerScore>().AddScore(1000);
			}
			p.gameObject.GetComponent<Dead>().isDead = false;
		}//foreach
	}

	bool EveryBodyDead()
	{
		foreach(GameObject p in m_players)
		{
			if(!p.GetComponent<Dead>().isDead)
			{
				return false;
			}
		}
		
		return true;
	}

}

