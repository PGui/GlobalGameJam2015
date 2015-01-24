using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {

	public Sprite[] characters;

	// Use this for initialization
	void Start () {
		int id = GetComponentInParent<PlayerID>().GetPlayerID();
		GetComponent<SpriteRenderer>().sprite = characters[id-1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
