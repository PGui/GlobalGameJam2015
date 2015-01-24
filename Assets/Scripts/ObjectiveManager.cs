using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{

	enum eObjectives
	{
		NONE = -1,
		CAT_AND_MICE = 0,
		//BIG_BALLS,
		//ROOF,
		//FIRE,
		//LITTLE_BALLS,

		SIZE
	}

	eObjectives currentObjective {get; set;}

	public float timeBeforeObjective = 3.0f;
	private float time = 0.0f;

	//Scripts Objectives


	// Use this for initialization
	void Start () 
	{
		currentObjective = eObjectives.NONE;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentObjective == eObjectives.NONE)
		{
			if(time >= timeBeforeObjective)
			{
				time = 0.0f;
				//currentObjective = Random.Range(0,eObjectives.SIZE);
				//Debug.Log("New Objective ! = " + currentObjective);
			}
			else
				time += Time.deltaTime;
		}
		else
		{
			switch(currentObjective)
			{
			case eObjectives.CAT_AND_MICE:
				Debug.Log("Cat and mice obj");
				break;
			default:
				Debug.Log("Objective error");
				break;
			}
		}


	}
}
