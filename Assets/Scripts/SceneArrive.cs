using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * 칸에 도착할 때 마다 숫자를 보여주는 스크립트
 */
public class SceneArrive : MonoBehaviour {
    //어딘지 나타내는 Text
    Text rouletteNumber;
    //현재 캐릭터
    GameObject currentPlayer;
	GameObject rouletteImg;
    //시간
    float currentTime = 0;
    //화면 지속 시간
    public int duraition = 3;

	// Use this for initialization
	void Start () {
        //rouletteNumber = GameObject.Find("NumberText").GetComponent<Text>();
        //currentPlayer = GameObject.Find("CharacterImage");
        //rouletteNumber.text = "" + GameData.scenarioDice[GameData.currentDice]; //현재 나온 주사위의 숫자를 보여준다.
		rouletteImg = GameObject.Find("RouletteImage");
        Debug.Log("현재 주사위 시나리오 번호 : " + GameData.currentDice);
		rouletteImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("roulette/roulette_" + GameData.scenarioDice[GameData.currentDice]); // 현재 차례 캐릭터 나타냄
        GameData.currentDice++; //다이스 순서 다음으로 넘기기
        GameData.currentDice = GameData.currentDice % GameData.scenarioDice.Length;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > duraition)
        {
            //PageMove.OnClickDice();
            SceneManager.LoadScene(21); //칸 도착 씬으로 넘기기
        }

    }

    /*private void MoveToKan()
    {
        //칸에 따라 각 해당 씬으로 보냄
        if (GameData.GetCurrentCharacter().position.Equals("퀴즈"))
            SceneManager.LoadScene(12);

    }*/
}
