using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {
	public Text DataText;

	// Use this for initialization
	void Start () {
		DataText.text = "Data goes here...";
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("HUD update.");

	}
}
