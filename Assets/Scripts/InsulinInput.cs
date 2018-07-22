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
        }
        //insulinVal[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("InsulinSet/"+"insulin_push_30");
        

        //인슐린 용량 저장 배열을 플레이어 수만큼 크기 지정ㅁ
        insulinAmount = new int[GameData.playerCount];

		//이름 적기
		currentTarget = GameObject.Find("TargetName");
		//캐릭터 세팅
		playerImage = GameObject.Find("playerImage");

        //요소 가져오기
        //insulinSection = GameObject.Find("CharacterSection");
        //insulinInput = new GameObject[GameData.playerCount];
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
		//캐릭터 이미지 지
		playerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + GameData.playerList[page]);
		
    }

    public void OnClickNextBtn()
    {
		//플레이어 리스트의 인슐린 양을 다 받았다 -> 다음 페이지로
		if((page+1) == GameData.playerList.Length){
			PageMove.OnClickInputDoneBtn();
		} else {
			page++;
			SetCharacter();
		}
    }

    /**
     * 6개 토글 누를 때 마다 값 변경
     */
     /*
    public void OnClickInsulinVal()
    {
        //켜진 것을 체크하고, 이미지도 정돈
        for (int i=0; i<insulinVal.Length; i++)
        {
            if (insulinVal[i].GetComponent<Toggle>().isOn)  //토글이기 때문에 한번만 걸릴 것임
            {
                GameData.GetCurrentCharacter().inputInsulin = 20 + (5*i); //20~45 중 하나가 들어가게 됌
                //눌린 이미지로 변경
                insulinVal[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("InsulinSet/" + "insulin_push_" + (20+(5*i)));
            }
            else //안 눌린 버튼 세팅
            {
                insulinVal[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("InsulinSet/" + "insulin_default_" + (20 + (5 * i)));
            }
        }
    }*/
}
