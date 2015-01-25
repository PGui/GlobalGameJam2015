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

	public float rectWidth = 500.0f;
	public float rectHeight = 70.0f;

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
		/*GameObject[] m_playerManagers = GameObject.FindGameObjectsWithTag("pm");
		if(m_playerManagers.Length >=2)
		{
			//Too muck playerManagerdeleting
			for(int i = 0; i < m_playerManagers.Length - 1 ; ++i)
			{
				GameObject.Destroy(m_playerManagers[i]);
			}
		}
*/

        ratioX = Screen.width/  1920.0f;
        ratioY = Screen.width / 1080.0f ;

        for (int i = 0; i < m_maxPlayers; ++i)
        {
            if (Input.GetButtonUp("P" + (i + 1).ToString() + " A"))
            {
                m_playerManager.GetPlayerTab()[i] = !m_playerManager.GetPlayerTab()[i];
            }

			if (Input.GetButton("P" + (i + 1).ToString() + " Start") && m_playerManager.GetPlayerTab()[i] /*&& m_playerManager.GetCurrentPlayerNumber() >= 2*/)
			{
				m_playerManager.SetInGame(true);

       
                Application.LoadLevel("Level");
                //Application.LoadLevel("Mini Cuvette");
                
            }

			if (Input.GetButtonUp("P" + (i + 1).ToString() + " B"))
			{
				Application.LoadLevel("Credits");
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
			/*
            if (i == 0)
            {
				GUI.color = new Color(0.51f,0.929f,0.709f);
				
			}
            if (i == 1)
            {
				GUI.color = new Color(0.709f,0.007f,0.07f);
			}
			if (i == 2)
            {
				GUI.color = new Color(0.470f,0.830f,0.8940f);
			}
			if (i == 3)
            {
				GUI.color = new Color(1.0f,0.890f,0.4860f);
			}
			*/
			GUI.color = Color.black;
			//GUI.Box(new Rect(10.0f * ratioX, 50.0f + (i * 30.0f * ratioY), 500.0f * ratioX, 30.0f * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			GUI.Box(new Rect(((Screen.width/4.0f) * (float)i + 100)* ratioX,( Screen.height - 200.0f) * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
		}
		GUI.color = oldColor;

		GUI.Box(new Rect((Screen.width/2.0f - rectWidth/2.0f), Screen.height - 80.0f * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Press start to Begin !");
		GUI.Box(new Rect((Screen.width/2.0f - rectWidth/2.0f), Screen.height - 50.0f * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Press B to see the Credits !");

			//GUI.Box(new Rect(boxCredits.x * ratioX, boxCredits.y * ratioY, boxCredits.z * ratioX, boxCredits.w * ratioY), "Press B to credits");

    
    }




}
