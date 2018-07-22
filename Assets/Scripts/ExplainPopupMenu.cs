using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 설명 팝업 창
 */
public class ExplainPopupMenu : MonoBehaviour {
    
    public const int LUCY = 0;
    public const int MARIE = 1;
    public const int MATT = 2;
    public const int VICTOR = 3;
    
    //캐릭터 수
    const int ALL_PAGE = 4;
    //팝업 창
    GameObject explainMenu;
    //이미지 창
    GameObject charImg;
    //이름 창
    GameObject charName;
    //능력 타이틀, 내용
    GameObject abilityT, abilityTxt;
    //스토리
    GameObject charStory;
    //패이지 부분
    GameObject pageText;
    
    //페이지
    int pageNum = 0;
    //현재 나타내는 page
    //순서 배열 - 마리 매트 루시 빅터
    //int[] order = {MARIE, MATT, LUCY, VICTOR};
    //나타낼 페이지
    int currentPage = 0;
    //캐릭터 이름 배열
    string[] names = {"마리", "매트", "루시", "빅터"};
    //캐릭터 파일명
    string[] fileName = { "Marie", "Matt", "Lucy", "Victor"};
    //캐릭터 스토리
    string[] story = 
        {"마리는 동화책 읽는 걸 좋아하는 8살이에요. \n 쿠키같은 간식을 먹으면서 책 읽는 걸 제일로 좋아해요!",
        "매트는 학교에서 과학을 제일 잘하는 9살이에요. \n 여러가지 실험을 하는 과학시간을 가장 좋아한답니다!",
        "루시는 반에서 가장 웃음이 많은 9살이에요. \n 운동을 좋아하는 루시는 운동 중에서도 수영을 가장 좋아해요!",
        "반장인 빅터는 친구들을 잘 도와주는 11살이에요. \n 공부도 잘해서 친구들이 모르는 문제를 척척 가르쳐준답니다!" };
    string[] abilityTitle =
    {
        "\"사물함 아이템 2배\"",
		"\"실험실 성공 100%\"",
		"\"몬스터 잡기 100%\"",
		"\"제비 미리보기\""
    };
    string[] ability =
    {
        "비밀의 사물함 칸에 도착했을 때, \n 사물함에 있는 아이템이 2배로 늘어나요!",
        "실험실 칸에 도착했을 때, \n 캔디가 몇 개이든 캔디가 2배로 펑펑 늘어나요!",
        "몬스터 칸에 도착했을 때, \n 캔디가 몇 개이든 무조건 몬스터를 잡을 수 있어요!",
        "퀴즈 칸에 도착해서 퀴즈를 맞혔을 때, \n 받을 수 있는 캔디의 개수가 적힌 제비를 미리 볼 수 있어요!"
    };

    //pre, next button
    GameObject nextBtn, preBtn;
    
	// Use this for initialization
	void Start () {
        //?버튼 누를 시 뜨는 팝업 설명 창 (캐릭터)
        explainMenu = GameObject.Find("CharMenu");
        //캐릭터 이미지 부분
		charImg = GameObject.Find("CharacterImg");
        //캐릭터 이름 부분
        charName = GameObject.Find("CharaterName");
        //스토리 부분
        charStory = GameObject.Find("CharaterStory");
        //페이지 text 부분
        pageText = GameObject.Find("PageText");
        //Next/Previous button
        nextBtn = GameObject.Find("NextButton");
        preBtn = GameObject.Find("PreviousButton");
        //능력 부분
        abilityT = GameObject.Find("CharaterAbilityTitle");
        abilityTxt = GameObject.Find("CharaterAbilityText");

        //맨 처음에는 안 보이는 상태로
        explainMenu.transform.localScale = new Vector3(0, 1, 1);

        //페이지 내 정보 보여주기
        DisplayInfo();
    }

    /**
     * 물음표 버튼 누를 시 동작하는 함수
     */
    public void OnClickInfoBtn()
    {
        //메뉴 보여지게 함
        explainMenu.transform.localScale = new Vector3(1, 1, 1);
    }

    /**
     * 팝업 설명창의 X 버튼 누를 시 동작하는 함수
     */
    public void OnClickXButton()
    {
        //메뉴 없어지게 함
        explainMenu.transform.localScale = new Vector3(0, 1, 1);
    }

    /**
     * 한페이지 내 정보 보여주기
     */
    public void DisplayInfo()
    {
        ShowImage();
        ShowName();
        ShowStory();
        ShowPageText();
        ShowAbility();
    }

    private void ShowAbility()
    {
        abilityT.GetComponent<Text>().text = abilityTitle[currentPage];
        abilityTxt.GetComponent<Text>().text = ability[currentPage];
    }

    /**
     * 캐릭터 스토리 보여주는 함수
     */
    private void ShowStory()
    {
        charStory.GetComponent<Text>().text = story[currentPage];
    }

    /**
     * 캐릭터 보여주기
     */
    private void ShowName()
    {
        charName.GetComponent<Text>().text = names[currentPage];
    }

    /**
     * 캐릭터 이미지 보여주는 함수
     */
    private void ShowImage()
    {
		charImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + fileName[currentPage]);
    }

    public void OnClickNextBtn()
    {

        if (currentPage < 3)
        {
            currentPage++;
            DisplayInfo();
        }
    }

    public void OnClickPreviousBtn()
    {
        if (currentPage > 0)
        {
            currentPage--;
            DisplayInfo();
        }
    }

    /**
     * 페이지 번호 보여지는 부분
     */
    private void ShowPageText()
    {
        pageText.GetComponent<Text>().text = (currentPage + 1) + " / " + ALL_PAGE;
    }

    /**
     * 버튼 작동 안되게 하는 효과까지 주고 싶은 경우에는
     * 아래 주석을 풀 것
     */
    /*void Update()
    {
        if (currentPage < 1)
        {
            preBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            preBtn.GetComponent<Button>().interactable = true;
        }

        if (currentPage > 2)
        {
            nextBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            nextBtn.GetComponent<Button>().interactable = true;
        }
    }*/
}
