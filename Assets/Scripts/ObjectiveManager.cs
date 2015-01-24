using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{
	public enum eObjectives
	{
		NONE = -1,
		CAT_AND_MICE,
		LITTLE_BALLS,
		FOOTBALL,
		//BIG_BALLS,
		//ROOF,
		//FIRE,


		SIZE
	}

	public eObjectives currentObjective {get; set;}

	public float timeBeforeObjective = 3.0f;
	private float time = 0.0f;

	//Objective text (objectif+time'sup)
	GUIText m_objectiveText;
	public float m_timeDisplayObjectiveText = 5.0f;
	bool m_needDisplayObjectiveText = false;
	private float timeElapsedObjectiveText = 0.0f;

	public float m_timeDisplayTimesUp = 3.0f;
	public bool m_needDisplayTimesUp {get; set;}
	private float timeElapsedTimesUp = 0.0f;

	GameObject[] m_players;

	//Scripts Objectives
	CatAndMices scriptCatAndMices;
	BigBall scriptBigBalls;
	Football scriptFoot;

	// Use this for initialization
	void Start () 
	{
		m_needDisplayTimesUp = false;
		//Get the objective text
		m_objectiveText = GameObject.Find("ObjectiveText").GetComponent<GUIText>();

		currentObjective = eObjectives.NONE;
		scriptCatAndMices = GetComponent<CatAndMices>();
		scriptBigBalls = GetComponent<BigBall>();
		scriptFoot = GetComponent<Football>();

		m_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentObjective == eObjectives.NONE && !m_needDisplayTimesUp)//Si aucun Objectif
		{
			if(time >= timeBeforeObjective)
			{
				time = 0.0f;
				int icurrentObjective = Random.Range(0,(int)eObjectives.SIZE);
				currentObjective = (eObjectives)icurrentObjective;
				//currentObjective = Random.Range(0,eObjectives.SIZE);
				m_needDisplayObjectiveText = true;
			}
			else
				time += Time.deltaTime;
		}
		else if(m_needDisplayTimesUp)//Si on affiche la fin d'un objectif
		{
			m_objectiveText.enabled = true;
			m_objectiveText.text = "Time's Up";
			timeElapsedTimesUp += Time.deltaTime;

			//Revive all the players
			//foreach(GameObject p in m_players)
			//{
			//	p.gameObject.GetComponent<Dead>().isDead = false;
			//}//foreach
		}
		else//Si on rentre dans un nouveau objectif
		{
			if(m_needDisplayObjectiveText && (timeElapsedObjectiveText < m_timeDisplayObjectiveText))
			{
				m_objectiveText.enabled = true;
				switch(currentObjective)
				{
				case eObjectives.CAT_AND_MICE:
					m_objectiveText.text = scriptCatAndMices.Phrase;
					break;
				case eObjectives.LITTLE_BALLS:
					m_objectiveText.text = scriptBigBalls.Phrase;
					break;
				case eObjectives.FOOTBALL:
					m_objectiveText.text = scriptFoot.Phrase;
					break;
				default:
					Debug.Log("Objective error");
					break;
				}
				timeElapsedObjectiveText += Time.deltaTime;
			}
			else
			{
				m_needDisplayObjectiveText = false;
				timeElapsedObjectiveText = 0.0f;
				switch(currentObjective)
				{
				case eObjectives.CAT_AND_MICE:
					m_objectiveText.enabled = false;
					scriptCatAndMices.enabled = true;
					break;
				case eObjectives.LITTLE_BALLS:
					m_objectiveText.enabled = false;
					scriptBigBalls.enabled = true;
					break;
				case eObjectives.FOOTBALL:
					m_objectiveText.enabled = false;
					scriptFoot.enabled = true;
					break;
				default:
					Debug.Log("Objective error");
					break;
				}
			}
		}

		//Stop displaying time's up
		if(m_needDisplayTimesUp && timeElapsedTimesUp >= m_timeDisplayTimesUp)
		{
			m_objectiveText.enabled = false;
			m_needDisplayTimesUp = false;
			timeElapsedTimesUp = 0.0f;
		}


	}
}
