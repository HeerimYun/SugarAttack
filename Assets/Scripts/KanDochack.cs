using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanDochack : MonoBehaviour {
    //시간
    float currentTime = 0;
    //화면 지속 시간
    public int duraition = 3;
    //칸 도착 정보
    Text kanText;
	GameObject rouletteImg;

	//영어 칸
	string board;

    // Use this for initialization
    void Start () {
		KEChange (GameData.board[GameData.GetCurrentCharacter().position]);

		rouletteImg = GameObject.Find ("RouletteImage");
		rouletteImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("arrive/dochak_" + board); // 현재 차례 캐릭터 나타냄
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > duraition)
            PageMove.OnClickDice();
    }

	void KEChange(string Kboard) {
		//일단 프로토타입 4개만
		if (Kboard.Equals ("급식")) {
			board = "cafeteria";
		} else if (Kboard.Equals ("식사")) {
			board = "eating";
		} else if (Kboard.Equals ("퀴즈")) {
			board = "quiz";
		} else if (Kboard.Equals ("상황")) {
			board = "situation";
		} else {
		}
	}
}
