using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharOrder : MonoBehaviour {

    //랜덤 객체
    //System.Random random = new System.Random();

    //받아올 것들
    bool[] toggleOn; //토글 on 여부 전체 배열
    string[] tNameList; //토글버튼 이름 전체 배열

    //선택된 캐릭터 리스트
    int[] playerList;

    //플레이어 목록 이름 배열
    string[] pNameList;

    //플레이어 수
    int playerCount;

    //순서 나타나는 부분
    GameObject CharSection;

    //플레이어 (텍스트 + 이미지) 부분
    GameObject[] player;

    //플레이어 텍스트
    Text[] pText;

    //플레이어 이미지
    Image[] pImg;

    //텍스트 배열
    public static string[] playOrderName;

    // Use this for initialization
    void Start () {
        Debug.Log("CharOrder 시작");
        //UI 요소 찾아오기
        CharSection = GameObject.Find("CharSection");

        //화면 배열 생성
        player = new GameObject[CharSelect.ALL_PLAYER];
        pText = new Text[CharSelect.ALL_PLAYER];
        pImg = new Image[CharSelect.ALL_PLAYER];

        //배열 초기화 
        for (int i = 0; i < 4; i++)
        {
            player[i] = GameObject.Find("p" + (i + 1)); //p1, p2 ... 찾기
            pText[i] = GameObject.Find("Text" + (i + 1)).GetComponent<Text>(); //각 텍스트 찾기
            pImg[i] = GameObject.Find("Image"+(i+1)).GetComponent<Image>(); //각 이미지 찾기
        }

        //배열 생성
        toggleOn = new bool[CharSelect.ALL_PLAYER];
        tNameList = new string[CharSelect.ALL_PLAYER];

        //배열 복사
        GetArrays();

        //참가자 수 세기
        playerCount = GetPlayerCount();

        //참가자 수 만큼의 배열 생성
        MakePlayerList();
       
        //화면에 textSetting 하기
        SetText();
    }

    /**
     * 화면에 플레이어 순서 보여주는 메서드 
     */
    private void SetText()
    {
        //크기 활성화
        for (int i=0; i<playerCount; i++)
        {
            player[i].transform.localScale += new Vector3(0, 1, 0); //감춰뒀던 것 펼치기
            //pText[i].text = pNameList[i]; //Text 나타내기
            pText[i].text = GameData.pStrList[i]; //한글이름으로 나타내기 
            pImg[i].sprite = Resources.Load<Sprite>("Characters/" + pNameList[i] + "/idle/" + pNameList[i] + "_idle_01"); //이미지 나타내기
        }

        //몇명인지 파악하고, case로 나누기
        switch(playerCount) {
            case 2:
                //2명일 경우의 placing
                player[0].transform.localPosition = new Vector3(-200, 211 , 0);
                player[1].transform.localPosition = new Vector3(200, 211, 0);
                break;
            case 3:
                //3명일 경우의 placing
                player[0].transform.localPosition = new Vector3(-300, 211, 0);
                player[1].transform.localPosition = new Vector3(0, 211, 0);
                player[2].transform.localPosition = new Vector3(300, 211, 0);
                break;
            case 4:
                player[0].transform.localPosition = new Vector3(-400, 211, 0);
                player[1].transform.localPosition = new Vector3(-150, 211, 0);
                player[2].transform.localPosition = new Vector3(100, 211, 0);
                player[3].transform.localPosition = new Vector3(350, 211, 0);
                break;
        }
    }

    /**
     * 참가한 플레이어 이름 리스트를 만드는 메서드
     */
    private void MakePlayerList()
    {
        Debug.Log("MakePlayerList 시작");
        //참가자 수만큼의 배열 생성
        pNameList = new string[playerCount];
        Debug.Log("playerCount : " + playerCount);

        //참가자 채워넣기
        int k = 0;

        for(int i=0; i<toggleOn.Length; i++)
        {
            if(toggleOn[i])
            {
                pNameList[k] = tNameList[i];
                Debug.Log(k+"번째 pNameList : " + pNameList[k]);
                k++;
            }
        }

        CopyList(); //GameData에 배열 저장
    }

    /**
     * GameData에 pNameList 배열을 복사하여 저장
     */
    private void CopyList()
    {
        GameData.playerList = new string[pNameList.Length];
        for(int i=0; i<pNameList.Length; i++)
        {
            GameData.playerList[i] = pNameList[i];
        }
        //GameData.isCharSelected = true;

        //GameData의 MakeCharacterList() 함수를 호출할 것
        GameData.MakeCharacterList();
        Debug.Log("플레이 리스트 저장");
    }

    /**
     * 참가한 플레이어 수를 반환하는 메서드
     * @return 클릭된 캐릭터 수
     */
    private int GetPlayerCount()
    {
        int count = 0;

        //toggle 켜진 것만 세기
        for(int i=0; i<toggleOn.Length; i++)
        {
            if(toggleOn[i])
            {
                count++;
            }
        }

        return count;
    }

    private void GetArrays()
    {
        Debug.Log("배열 복사 시작");
        //on 배열 복사
        for (int i=0; i<toggleOn.Length; i++)
        {
            toggleOn[i] = CharSelect.toggleOn[i];
            tNameList[i] = CharSelect.toggleNameList[i];
            Debug.Log("복사된 배열 정보 : "+ i +"번째" + tNameList[i]+ "의 상태는 " + toggleOn[i]);
        }
    }

    /**
     * 순서를 화면에 나타내는 함수
     */
     public void ShowOrder(int count)
    {
        switch(count)
        {
            case 2:
                //해당 section 활성화
                CharSection.transform.Find("2players").transform.localScale += new Vector3(0, 1, 0);
                break;
            case 3:
                //해당 section 활성화
                CharSection.transform.Find("3players").transform.localScale += new Vector3(0, 1, 0);
                break;
            case 4:
                //해당 section 활성화
                CharSection.transform.Find("4players").transform.localScale += new Vector3(0, 1, 0);
                break;
        }
    }
}
