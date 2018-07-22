using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SituationRoom : MonoBehaviour {

    GameObject situationText;
	GameObject situationImg;
	// Use this for initialization
	void Start () {
        //situationText = GameObject.Find("SituationText");

		situationImg = GameObject.Find ("SituaitionImage");
		situationImg.GetComponent<Image>().sprite = Resources.Load<Sprite> ("situation/situation_" + GameData.GetCurrentPlayerName());

        //situationText.GetComponent<Text>().text = GameData.situation[1]; //옥상
        GameData.GetCurrentCharacter().bloodSugar += GameData.situationVal[1]; //옥상
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GameData.TurnChange();
        }
	}
}
