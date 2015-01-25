﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public bool _debug = false;

    public GameObject playerPrefab;

    //Number of player Max
    private const int m_maxPlayers = 4;

    private bool[] m_playersIDs = new bool[m_maxPlayers];

    private bool m_inGame = false;

    //Put to false when entering ingame, put to true when exiting in game
    private bool m_needIDGeneration = true;

    //Spawner Tab
    private GameObject[] m_SpawnerTab;

    public bool m_playerVictory { get; set; }

    private SpawnerManager SpawnManager;
    private GameObject[] m_players;

    public GameObject m_playerWinner { get; set; }

	public int scoreNeededToWin = 20000;

    void Awake()
    {
        //Keep the manager everywhere
        DontDestroyOnLoad(transform.gameObject);

       for(int i = 0; i < m_maxPlayers; ++i)
       {
           m_playersIDs[i] = false;//Put everything to false
       }

        if(_debug)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; ++i)
             {
                 players[i].GetComponent<PlayerID>().SetID(i + 1);
             }
        }

        m_playerVictory = false;
    }

	//Coroutine pour le spawn des joueurs
	IEnumerator SpawnPlayers() 
	{
		yield return new WaitForSeconds(0.2f);
		m_SpawnerTab = GameObject.FindGameObjectsWithTag("Spawner");
		for (int i = 0; i < m_maxPlayers; ++i)
		{
			if (m_playersIDs[i])//If the player is here
			{
				GameObject player = Object.Instantiate(playerPrefab, m_SpawnerTab[i].transform.position, Quaternion.identity) as GameObject;//Instanciate the player at a 
				player.GetComponent<PlayerID>().SetID(i + 1);//Set his ID
				player.GetComponent<Twinkle>().enabled = true;

				//player.GetComponent<PlayerControl>().m_hasControl = false;
				
				//return i + 1;//Return the id of the player
			}
		}
		//GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().enabled = true;
		m_players = GameObject.FindGameObjectsWithTag("Player");
		GameObject.Find("InGameInterface").GetComponent<InGameInterface>().enabled = true;
	}


    void Update()
    {
        if(!_debug && m_needIDGeneration && m_inGame)
        {
            m_needIDGeneration = false;
            
            //Get the spawners
			StartCoroutine("SpawnPlayers");
           // m_SpawnerTab = GameObject.FindGameObjectsWithTag("Spawner");
			/*
            for (int i = 0; i < m_maxPlayers; ++i)
            {
                if (m_playersIDs[i])//If the player is here
                {

                    GameObject player = Object.Instantiate(playerPrefab, m_SpawnerTab[i].transform.position, Quaternion.identity) as GameObject;//Instanciate the player at a 
					player.GetComponent<PlayerID>().SetID(i + 1);//Set his ID
                    player.GetComponent<Twinkle>().enabled = true;
                    //player.GetComponent<PlayerControl>().m_hasControl = false;
                   
                    //return i + 1;//Return the id of the player
                }
            }
            //GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().enabled = true;
            GameObject.Find("InGameInterface").GetComponent<InGameInterface>().enabled = true;
*/
           // m_players = GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().m_players;
            //if (m_players.Length == 0)
            //{
            //    Debug.Log("Do not work");
            //}
        }

        

        //Check every frame if there is a winner
		if (m_players != null && m_inGame && m_needIDGeneration == false && !m_playerVictory)
		{
			for (int i = 0; i < m_players.Length; ++i)
			{
				if (m_players != null && m_players[i].GetComponent<PlayerScore>().m_playerScore >= scoreNeededToWin)
				{
					m_players[i].GetComponent<PlayerScore>().m_playerScore = scoreNeededToWin;
					m_playerVictory = true;
					m_playerWinner = m_players[i];
				}
			}

			if(m_playerVictory)
			{
				//GameObject.Find("ObjectiveManager").SetActive(false);
				GameObject.Find("ObjectiveText").SetActive(false);
				for (int i = 0; i < m_players.Length; ++i)
				{
						m_players[i].GetComponent<Control>().enabled = false;
						m_players[i].rigidbody2D.velocity = Vector2.zero;
						m_players[i].GetComponentInChildren<MeshRenderer>().enabled = true;
				}
			}

		}
		   /*
        if (m_inGame && m_needIDGeneration == false && !m_playerVictory)
        {
            for (int i = 0; i < m_players.Length; ++i)
            {
                if (m_players[i].GetComponent<PlayerScore>().m_playerScore >= m_PointCount)
                {
                    m_players[i].GetComponent<PlayerScore>().m_playerScore = m_PointCount;
                    m_playerVictory = true;
                    m_playerWinner = m_players[i];
                    break;
                }
            }
        }
        */

        if (_debug)
        {
			//StartCoroutine("SpawnPlayers");
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                p.GetComponent<Control>().m_hasControl = true;
            }
        }

    }
	
    public void ResetToMenu()
    {
        m_inGame = false;
        m_needIDGeneration = true;
        m_playerVictory = false;
        m_playerWinner = null;
        m_playerVictory = false;
        Time.timeScale = 1.0f;
        for (int i = 0; i < m_players.Length; ++i)
        {
            //GameObject.Destroy(m_players[i]);
            m_players[i].GetComponent<PlayerScore>().m_playerScore = 0;
            
        }

        //GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().enabled = false;

    }

    public void Reset()
    {
       
        m_needIDGeneration = true;
        m_playerVictory = false;
        m_playerWinner = null;
        m_playerVictory = false;
        Time.timeScale = 1.0f;
        for (int i = 0; i < m_players.Length; ++i)
        {
            GameObject.Destroy(m_players[i]);
            //m_players[i].GetComponent<PlayerScore>().m_playerScore = 0;

        }

       // GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().enabled = false;
        GameObject.Find("InGameInterface").GetComponent<InGameInterface>().enabled = false;
    }

    public bool[] GetPlayerTab()
    {
        return m_playersIDs;
    }

    public bool IsInGame()
    {
        return m_inGame;
    }

    public void SetInGame(bool inGame)
    {
        m_inGame = inGame;
    }

    public int GetCurrentPlayerNumber()
    {
        int playerNumber = 0;
        for (int i = 0; i < m_maxPlayers; ++i)
        {
            if (m_playersIDs[i])
                ++playerNumber;
        }
        return playerNumber;
    }


    /*
     * This function returns an ID if there is one disponible, otherwise, it returns 0
     * Called in the script PlayerID in the player prefab
     */
    public int GetID()
    {
        for (int i = 0; i < m_maxPlayers; ++i)
        {
           if(!m_playersIDs[i])//If there is some place
           {
               m_playersIDs[i] = true;

               return i + 1;//Return the id of the player
           }
        }

        return 0;//if there is no more place
    }


    /*
    * This function retrieves an ID put in the parameter
    * Called in the script PlayerID in the function OnDestroy()
    */
    public void GetIDBack(int ID)
    {
        if(ID > 0 && ID <= m_maxPlayers)
        {
            m_playersIDs[ID - 1] = false;
        }
    }

    public int GetMaxPlayer()
    {
        return m_maxPlayers;
    }
}
