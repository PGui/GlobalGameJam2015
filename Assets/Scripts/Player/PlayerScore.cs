using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {


    public int m_playerScore { get; set; }


	// Use this for initialization
	void Start ()
    {
        m_playerScore = 0;
	}

	public void AddScore(int scoreToAdd)
	{
		m_playerScore += scoreToAdd;
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}
}
