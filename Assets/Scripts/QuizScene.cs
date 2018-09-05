using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Quiz 씬 스크립트
 * Quiz를 띄워주고 정답 확인할 수 있음
 */
public class QuizScene : MonoBehaviour {

    float currentTime = 0;

    GameObject question; //문제 부분
    public static bool isAnswer = false; //정답 여부
    bool playerAnswer = false; //입력 받은 정답

    GameObject oBtn, xBtn; //O X 버튼
    GameObject checkAnswerBtn; //정답 확인 버튼

    //answer panel
    GameObject answerResult;
	GameObject answerImg; //현재 캐릭터 이미지 공간
    GameObject isTrueOfFalse; //맞았어요! or 틀렸어요!

    bool isTimeToMove = false;
    // Use this for initialization
    void Start () {
        //로딩
        question = GameObject.Find("QuizText");
        oBtn = GameObject.Find("OButton");
        xBtn = GameObject.Find("XButton");
        checkAnswerBtn = GameObject.Find("CheckAnswerBtn");
        answerResult = GameObject.Find("CheckAnswer");
		answerImg = GameObject.Find ("Character");
        isTrueOfFalse = GameObject.Find("TrueFalse");

        //퀴즈 띄우기
        question.GetComponent<Text>().text = GameData.quizQuestion[GameData.curQuiz];
        //GameData.curQuiz++; //다음 퀴즈로 이동

        //퀴즈 인덱스 안넘도록 하기
        
        if (GameData.curQuiz > 2)
        {
            GameData.curQuiz = 0;
        }

        //처음에는 비활성화
        checkAnswerBtn.GetComponent<Button>().interactable = false;
	}

    /**
     * O 버튼 누를 때 호출
     */
    public void OnClickOBtn()
    {
        playerAnswer = true;
        //x버튼 색깔 바꾸기
        //oBtn.GetComponent<Image>().color = Color.white;
        //xBtn.GetComponent<Image>().color = Color.gray;
        Debug.Log("답 체크 : " + playerAnswer);

        if (!checkAnswerBtn.GetComponent<Button>().interactable)
        {
            checkAnswerBtn.GetComponent<Button>().interactable = true;
        }
    }

    /**
     * X 버튼 누를 때 호출
     */
    public void OnClickXBtn()
    {
        playerAnswer = false;
        //oBtn.GetComponent<Image>().color = Color.gray;
        //xBtn.GetComponent<Image>().color = Color.white;

        Debug.Log("답 체크 : " + playerAnswer);

        if (!checkAnswerBtn.GetComponent<Button>().interactable)
        {
            checkAnswerBtn.GetComponent<Button>().interactable = true;
        }
    }

    /**
     * 정답 확인하는 메서드
     */
    public void CheckAnswer()
    {
        //숨겨졌던 판넬 펼치고,
        answerResult.transform.localScale = new Vector3(1, 1, 1);
        
        //맞았는지 틀렸는지 알리기
        if (playerAnswer == GameData.quizAnswer[GameData.curQuiz])
        {
            isAnswer = true;
            //isTrueOfFalse.GetComponent<Text>().text = "맞았어요!";
			//캐릭터 보여주기
			answerImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("quiz/correct_" + GameData.GetCurrentPlayerName());
        }
        else
        {
            isAnswer = false;
			//isTrueOfFalse.GetComponent<Text>().text = "틀렸어요!";
			answerImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("quiz/incorrect_" + GameData.GetCurrentPlayerName());
        }
        GameData.curQuiz++;
        GameData.curQuiz = GameData.curQuiz % GameData.quizQuestion.Length;
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    
}
