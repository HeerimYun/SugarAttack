using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CharSelect : MonoBehaviour {
    //최대 인원은 4명
    public const int ALL_PLAYER = 4;

    //Character character;

    /* 상수 선언 */
    public const int LUCY = 0;
    public const int MATT = 1;
    public const int VICTOR = 2;
    public const int MARIE = 3;

    /* 4개의 캐릭터 토글 버튼*/ 
    GameObject lucy, marie, matt, victor;
    /*다음 버튼 */
    GameObject selectDoneBtn;

    //전체 캐릭터 배열 선언 및 초기화
    public static bool[] toggleOn = new bool[4] { false, false, false, false };
    
    //토글 이름 목록
    public static string[] toggleNameList;
    
    //활성화 된 캐릭터 수
    public static int playerCount = 0;

    // Use this for initialization
    void Start () {
        // 화면 캐릭터 토글 객체들 불러오기
        lucy = GameObject.Find("Lucy");
        marie = GameObject.Find("Marie");
        matt = GameObject.Find("Matt");
        victor = GameObject.Find("Victor");
        selectDoneBtn = GameObject.Find("SelectDoneBtn");

        //맨처음 버튼 비활성화
        if (selectDoneBtn != null)
        {
            selectDoneBtn.GetComponent<Button>().interactable = false;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(selectDoneBtn != null)
        {
            ButtonActive(SelectedCharCount());
        }
        //SetPlayerList();
	}

    /**
     * Scene1.2_CharSelect
     * 캐릭터 선택하는 함수
     * 각 캐릭터의 토글 버튼 여부가 배열에 들어감
     * 토글 켜짐 = true, 토글 꺼짐 = false
     */
    public void SetCharacter()
    {
        toggleOn[LUCY] = lucy.GetComponent<Toggle>().isOn;
        toggleOn[MATT] = matt.GetComponent<Toggle>().isOn;
        toggleOn[VICTOR] = victor.GetComponent<Toggle>().isOn;
        toggleOn[MARIE] = marie.GetComponent<Toggle>().isOn;
    }


    /**
     * Scene1.2_CharSelect
     * 몇 명이 선택되었는지 반환하는 함수
     * @return 선택된 플레이어 수
     */
    public int SelectedCharCount()
    {
        int count = 0; //초기화

        for (int i=0; i < toggleOn.Length; i++)
        {
            if (toggleOn[i]) //true일 때 count
                count++;
        }
        Debug.Log("선택 수: "+count);
        return count;
    }

    /**
     * Scene1.2_CharSelect
     * 두명 이상일 때만 다음 버튼이 활성화
     * @parameter 선택된 플레이어 수
     */
    public void ButtonActive(int charCount)
    {
        if (charCount >= 2) //2명 이상이면,
        {
            // 버튼을 활성화 한다.
            selectDoneBtn.GetComponent<Button>().interactable = true;
        }
        else //2명 이상이 아닐 시 
        {
            // 버튼을 비활성화
            selectDoneBtn.GetComponent<Button>().interactable = false;
        }
    }

    /**
     * 확인버튼 누르는 순간 전역변수에 write
     */
    public void SendData()
    {
        Debug.Log("sendData() 실행");
        //플레이어 수 write
        playerCount = SelectedCharCount();
        //리스트 만들기
        MakeToggleList(ALL_PLAYER);
        GameData.playerCount = playerCount;
        //GameData에서 객체 생성하도록 하기
    }

    public void MakeToggleList(int count)
    {
        toggleNameList = new string[count];

        Debug.Log("count: " + count);

        toggleNameList[LUCY] = "Lucy";
        toggleNameList[MARIE] = "Marie";
        toggleNameList[MATT] = "Matt";
        toggleNameList[VICTOR] = "Victor";
        
        for (int i=0; i<count; i++)
        {
            Debug.Log(i + "번째 토글이름 : " + toggleNameList[i]);
        }
    }
}
