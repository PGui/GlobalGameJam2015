using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {

	public Sprite[] characters;

	public RuntimeAnimatorController[] controller;

	// Use this for initialization
	void Start () {
		int id = GetComponentInParent<PlayerID>().GetPlayerID();
		//GetComponent<SpriteRenderer>().sprite = characters[id-1];
		GetComponent<Animator>().runtimeAnimatorController = controller[id-1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
