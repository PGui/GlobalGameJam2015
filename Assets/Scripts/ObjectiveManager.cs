using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{

	enum eObjectives
	{
		NONE,
		CAT_AND_MICE,
		//BIG_BALLS,
		//ROOF,
		//FIRE,
		//LITTLE_BALLS,

		SIZE
	}

	eObjectives currentObjective = eObjectives.NONE;

	public float timeBeforeObjective = 3.0f;
	private float time = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{



	}
}
