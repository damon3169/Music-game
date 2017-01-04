using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

public class Score_manager : MonoBehaviour {

	private int score= 0;

	[SerializeField]
	private Text scoreText; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text =  "Score: " + score;
	}

	public void addScore(int newScore){
		score += newScore;
	}

	public int getScore(){
		return score;
	}


}
