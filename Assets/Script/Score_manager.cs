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
        //Met a jour le score
		scoreText.text =  "Score: " + score;
	}

    //Permet de rajouter du score
    public void addScore(int newScore){
		score += newScore;
	}

    //Permet de récupérer le score
    public int getScore(){
		return score;
	}


}
