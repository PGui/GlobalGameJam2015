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

	public Vector2 posP1;
	public Vector2 posP2;
	public Vector2 posP3;
	public Vector2 posP4;

	public Vector2 textPos;
	public Vector2 textPos2;
	public Vector2 textPos3;

	// Use this for initialization
	void Start ()
    {
       // Random.seed = (int)Time.time;

		//posP1 = new Vector2(500.0f,100.0f);

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

		if (Input.GetKeyDown(KeyCode.Escape))
		{ 
			Application.Quit();
		}

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
            if (i == 0)
            {
				//GUI.color = new Color(0.51f,0.929f,0.709f);
				GUI.color = Color.black;
				GUI.Box(new Rect(posP1.x *ratioX , posP1.y*ratioX , rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			}
            if (i == 1)
            {
				GUI.color = Color.black;
				GUI.Box(new Rect(posP2.x *ratioX , posP2.y*ratioX , rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			}
			if (i == 2)
            {
				GUI.color = Color.black;
				GUI.Box(new Rect(posP3.x *ratioX , posP3.y*ratioX , rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			}
			if (i == 3)
            {
				GUI.color = Color.black;
				GUI.Box(new Rect(posP4.x *ratioX , posP4.y*ratioX , rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			}

			//GUI.color = Color.black;
			//GUI.Box(new Rect(10.0f * ratioX, 50.0f + (i * 30.0f * ratioY), 500.0f * ratioX, 30.0f * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
			//GUI.Box(new Rect(((Screen.width/4.0f) * (float)i + 100)* ratioX,( Screen.height - 200.0f) * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Player " + (i + 1).ToString() + " " + (m_playerManager.GetPlayerTab()[i] ? "Ready !" : " not Ready."));
		}

		GUI.Box(new Rect(textPos.x  * ratioX, textPos.y * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Press start to Begin !");
		GUI.Box(new Rect(textPos2.x * ratioX, textPos2.y * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Press B to see the Credits !");
		GUI.Box(new Rect(textPos3.x  * ratioX, textPos3.y * ratioY, rectWidth * ratioX, rectHeight * ratioY), "Press A to be ready ! !");

			//GUI.Box(new Rect(boxCredits.x * ratioX, boxCredits.y * ratioY, boxCredits.z * ratioX, boxCredits.w * ratioY), "Press B to credits");

    
    }




}
