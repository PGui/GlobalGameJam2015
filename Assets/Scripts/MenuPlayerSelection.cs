using UnityEngine;
using System.Collections;

public class MenuPlayerSelection : MonoBehaviour {


    private PlayerManager m_playerManager;
    private int m_maxPlayers = -1;

    public int pointCountMin = 10;
    public int pointCountMax = 100;

    private float ratioX = 1920.0f / Screen.width ;
    private float ratioY =  1080.0f / Screen.height;

    float baseGuiFontSize = 5.0f;

    public float fontRatio = 5.0f;

    public GUISkin mySkin;

	public Vector4 boxCredits = new Vector4(500,30,10,10);

	// Use this for initialization
	void Start ()
    {
       // Random.seed = (int)Time.time;

        m_playerManager = GameObject.Find("PlayersManager").GetComponent<PlayerManager>();
        if (!m_playerManager)
        {
            Debug.Log("Can't get PlayerManager in MenuPlayerSelection");
        }

        m_maxPlayers = m_playerManager.GetMaxPlayer();

	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update ratio
        //ratioX = 1366.0f / Screen.width ;
        //ratioY =  768.0f / Screen.height;

        ratioX = Screen.width/  1920.0f;
        ratioY = Screen.width / 1080.0f ;


        for (int i = 0; i < m_maxPlayers; ++i)
        {
            if (Input.GetButtonUp("P" + (i + 1).ToString() + " A"))
            {
                m_playerManager.GetPlayerTab()[i] = !m_playerManager.GetPlayerTab()[i];
            }

            if (Input.GetButton("P" + (i + 1).ToString() + " Start") && m_playerManager.GetPlayerTab()[i])
            {
                m_playerManager.SetInGame(true);

       
                Application.LoadLevel("Level");
                //Application.LoadLevel("Mini Cuvette");
                
            }
        }
	}


    void OnGUI()
    {
        GUI.skin = mySkin;
		mySkin.box.fontSize = (int)(fontRatio * ratioX);
        Color oldColor = GUI.color;
        for (int i = 0; i < m_maxPlayers; ++i)
        {
            if (i == 0)
            {
                GUI.color = Color.cyan;
   
            }
            if (i == 1)
            {
                GUI.color = Color.red;
            }
            if (i == 2)
            {
                GUI.color = Color.yellow;
            }
            if (i == 3)
            {
                GUI.color = Color.green;
            }

            GUI.Box(new Rect(10.0f * ratioX, 50.0f + (i * 30.0f * ratioY), 500.0f * ratioX, 30.0f * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
        }
        GUI.color = oldColor;

        GUI.Box(new Rect(10.0f * ratioX, Screen.height - 50.0f * ratioY, 500.0f * ratioX, 30.0f * ratioY), "Press start to Begin");
    
		//GUI.Box(new Rect(boxCredits.x * ratioX, boxCredits.y * ratioY, boxCredits.z * ratioX, boxCredits.w * ratioY), "Press B to credits");

    
    }




}
