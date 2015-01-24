using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{

	public enum eObjectives
	{
		NONE = -1,
		CAT_AND_MICE = 0,
		//BIG_BALLS,
		//ROOF,
		//FIRE,
		//LITTLE_BALLS,

		SIZE
	}

	public eObjectives currentObjective {get; set;}

	public float timeBeforeObjective = 3.0f;
	private float time = 0.0f;

	//Scripts Objectives
	CatAndMices scriptCatAndMices;

	// Use this for initialization
	void Start () 
	{
		currentObjective = eObjectives.NONE;
		scriptCatAndMices = GetComponent<CatAndMices>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentObjective == eObjectives.NONE)
		{
			if(time >= timeBeforeObjective)
			{
				time = 0.0f;
				int icurrentObjective = Random.Range(0,(int)eObjectives.SIZE);
				currentObjective = (eObjectives)icurrentObjective;
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
				//Debug.Log("Cat and mice obj");
				scriptCatAndMices.enabled = true;
				break;
			default:
				Debug.Log("Objective error");
				break;
			}
		}


	}
}
