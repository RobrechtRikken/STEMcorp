using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRangeManager : MonoBehaviour {
	public int score;
	public Text scoreBoard;
	// Use this for initialization
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TargetIsHit()
	{
		score++;
		scoreBoard.text = score.ToString ();
		GetComponent<AudioSource> ().Play ();
	}
}
