using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTurn : MonoBehaviour {

    GameObject playerOrder;
    GameObject[] pList;
    GameObject currentTarget; //현재 플레이어의 이름
    string[] pStrList;

    GameObject characterImg; //해당 순서 캐릭터 이미지 부분

    

    //random
    System.Random roulette;
    // Use this for initialization
    void Start () {
        // 로딩
        //playerOrder = GameObject.Find("PlayerOrder");
        currentTarget = GameObject.Find("TargetName");
        characterImg = GameObject.Find("CharacterImage");

        //random
        roulette = new System.Random();

        //처음에 모든 순서 숨김
        for (int i=0; i<4; i++)
        {
            GameObject.Find("Player" + (i + 1)).GetComponent<Text>().text = "";
        }

        //왼쪽 순서 세팅, 해당 순서만 보일 것
        //SetplayerList();
        //현재 순서 누군지 체크
        GameData.CheckCurrent();
        //타겟 이름 설정
        currentTarget.GetComponent<Text>().text = GameData.currentPlayer;
        //아이템 text setting
        //SetItemBox();
        //캐릭터 세팅
        characterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + GameData.GetCurrentPlayerName());
	}

    

    private void GetPlayerStr()
    {
        pStrList = new string[GameData.playerCount];

        for(int i=0; i<pStrList.Length; i++)
        {
            pStrList[i] = GameData.playerList[i];
        }
    }

    private void SetplayerList()
    {
        //현재 화면에 순서 나타낼 것
        for(int i=0; i<GameData.playerCount; i++)
        {
            //이름 나타낼 것
            GameObject.Find("Player" + (i + 1)).transform.GetComponent<Text>().text = GameData.pStrList[i];
        }
    }

    
    /**
     * 가상 룰렛 버튼, 임시 함수
     */
    public void OnClickRoulette()
    {
        //int dice = roulette.Next(1, 7); //1부터 6까지 나옴
        //현재 플레이어의 위치 변경
        GameData.GetCurrentCharacter().position += GameData.scenarioDice[GameData.currentDice];
        Debug.Log("시나리오 주사위: " + GameData.scenarioDice[GameData.currentDice]);
        //GameData.GetCurrentCharacter().position += 2; //테스트로 식사칸에 도착하도록 설정
        //GameData.currentDice++; //다음 주사위 차례로 증가
        //GameData.currentDice = GameData.currentDice % GameData.scenarioDice.Length;
        //해당 칸에 따른 Scene으로 이동 하는 함수 호출
        SceneManager.LoadScene(20);
        //PageMove.OnClickDice();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
