using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Scene 1.3_InsulinInput
 * 인슐린 입력 페이지
 * 선택한 플레이어가 각 자신의 인슐린을 입력할 수 있도록 한다.
 */
public class InsulinInput : MonoBehaviour {

    //용량설정 하는 부분
    //GameObject insulinSection;

	//인슐린 용량 저장 배열
	int[] insulinAmount;

	//페이지 확인
	int page = 0;

    //인슐린 박스 배열
    GameObject[] insulinInput;

    //다음 (선택완료) 버튼
    GameObject nextBtn;

    //토글 버튼 받아오기
    GameObject[] insulinVal;

    //인슐린 토글 박스에서 값 받아오기
    int[] bloodSugar;

	GameObject currentTarget; //현재 플레이어의 이름
	GameObject playerImage;

    // Use this for initialization
    void Start () {
        //용량 6개 버튼
        insulinVal = new GameObject[6];
        for(int i=0; i<insulinVal.Length; i++)
        {
            insulinVal[i] = GameObject.Find("InsulinToggle" + (i + 1));
            //Debug.Log(insulinVal[i]);
        }

        //인슐린 용량 저장 배열을 플레이어 수만큼 크기 지정
        insulinAmount = new int[GameData.playerCount];

		//이름 적기
		currentTarget = GameObject.Find("TargetName");
		//캐릭터 세팅
		playerImage = GameObject.Find("playerImage");

        //요소 가져오기
        nextBtn = GameObject.Find("InputDoneBtn");

        //캐릭터별 인슐린 선택 나오기
        SetCharacter();
    }

    /**
     * 선택한 캐릭터의 인슐린 박스만 활성화 및 배치
     */
    private void SetCharacter()
    {
		//이름 지정 
		currentTarget.GetComponent<Text>().text = GameData.pStrList[page];
		//캐릭터 이미지
		playerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + GameData.playerList[page]);
    }

    /**
     * 선택완료 버튼
     */
    public void OnClickNextBtn()
    {
		//플레이어 리스트의 수 만큼 인슐린 양을 다 받았다 -> 다음 페이지로
		if((page+1) == GameData.playerList.Length){
			PageMove.OnClickInputDoneBtn();
		} else {
			page++;
			SetCharacter();
		}
    }

    /**
     * 6개 토글 누를 때 마다 값 변경
     * 누른 토글 버튼에 대해서는 해당 값으로 변수를 채우고,
     * 다음 버튼을 누를 시 값을 넘김
     */
     public void OnClickInsulinBtn()
    {  
        for (int i=0; i<6; i++)
        {
            if (insulinVal[i].GetComponent<Toggle>().isOn) //켜져있으면,
            {
                //해당 캐릭터의 인슐린 인풋 설정
                GameData.GetCharByName(currentTarget.GetComponent<Text>().text).inputInsulin = 20 + (i*5);
                Debug.Log(currentTarget.GetComponent<Text>().text + "의 전체 인슐린 : " + GameData.GetCharByName(currentTarget.GetComponent<Text>().text).inputInsulin);
            }
        }
    }
}
