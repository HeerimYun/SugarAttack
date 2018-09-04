using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/**
 * 순서 선택 퀴즈 유형
 * 클릭 순서를 배열로 받고, 정답 배열과 비교
 */
public class QuizScene3 : MonoBehaviour {

    float currentTime = 0;

    GameObject question; //문제 부분
    public static bool isAnswer = false; //정답 여부
    public int[] playerAnswer = { 0, 0, 0, 0 }; //사용자한테 입력 받은 정답
    public int[] answerArray = { 0, 0, 0, 0 }; //정답 배열
    public int curAnswer = 0; //플레이어 선택 배열의 현재 위치

    GameObject[] answer = new GameObject[4]; //선택지
    GameObject checkAnswerBtn; //정답 확인 버튼

    //answer panel
    GameObject answerResult;
    GameObject answerImg; //현재 캐릭터 이미지 공간
    GameObject isTrueOfFalse; //맞았어요! or 틀렸어요!

    bool isTimeToMove = false;
    
    // Use this for initialization
    void Start()
    {
        //로딩
        question = GameObject.Find("QuizText");
        for (int i = 0; i < answer.Length; i++) //선택지 4개 토글 버튼
        {
            answer[i] = GameObject.Find("AnswerToggle" + (i + 1));
        }

        checkAnswerBtn = GameObject.Find("CheckAnswerBtn");
        answerResult = GameObject.Find("CheckAnswer");
        answerImg = GameObject.Find("Character");
        isTrueOfFalse = GameObject.Find("TrueFalse");

        //퀴즈 띄우기
        question.GetComponent<Text>().text = GameData.quizQuestion[GameData.curQuiz];
        //GameData.curQuiz++; //다음 퀴즈로 이동

        //선택지에 그림 및 텍스트 띄우기


        //답이 될 순서 무작위로 배정
        int randomNum = 0;
        for(int i=0; i<answerArray.Length; i++)
        {
            randomNum = Random.Range(1, 4);

            if (answerArray[i] == randomNum) //이전 정답 배열에 들어있는 숫자와 같은 숫자가 나왔을 경우,
            {
                i--; //다시 뽑는다.
            }
            else //이전 정답과 다른 숫자가 뽑힌 경우
            {
                answerArray[i] = randomNum; //중복이 아니므로 정상적으로 정답으로 추가
            }
            Debug.Log("배정된 정답 - " + (i+1) + "번째: " + answerArray[i]);
        }

        

        //퀴즈 인덱스 안 넘도록 하기

        if (GameData.curQuiz > 2)
        {
            GameData.curQuiz = 0;
        }

        //처음에는 비활성화
        checkAnswerBtn.GetComponent<Button>().interactable = false;
    }

    /**
     * 4가지 선택지 토글 버튼 누를 때 호출하는 메서드
     * 현재 코드에 1 다음 바로 3이 써지는 버그가 있음
     */
    public void ChooseAnswer()
    {
        Debug.Log("현재 선택 개수: " + curAnswer);
        Debug.Log("현재 선택된 이름" + EventSystem.current.currentSelectedGameObject.name);
        //현재 클릭한 선택지 번호를 playerAnswer에 저장
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "AnswerToggle1":
                playerAnswer[curAnswer] = 1;
                curAnswer++;
                GameObject.Find("OrderText1").GetComponent<Text>().text = (curAnswer) + ""; 
                break;

            case "AnswerToggle2":
                playerAnswer[curAnswer] = 2;
                curAnswer++;
                GameObject.Find("OrderText2").GetComponent<Text>().text = (curAnswer) + "";
                break;

            case "AnswerToggle3":
                playerAnswer[curAnswer] = 3;
                curAnswer++;
                GameObject.Find("OrderText3").GetComponent<Text>().text = (curAnswer) + "";
                break;

            case "AnswerToggle4":
                playerAnswer[curAnswer] = 4;
                curAnswer++;
                GameObject.Find("OrderText4").GetComponent<Text>().text = (curAnswer) + "";
                break;
        }


        if (curAnswer == 3) //순서 4개를 모두 골랐을 경우에만 정답 확인 가능
        {
            checkAnswerBtn.GetComponent<Button>().interactable = true;
        }
        else if (curAnswer > 3)
        {
            curAnswer = 3;
        }
    }

    /**
     * 정답 확인하는 메서드
     */
    /*public void CheckAnswer()
    {
        //숨겨졌던 판넬 펼치고,
        answerResult.transform.localScale = new Vector3(1, 1, 1);

        //맞았는지 틀렸는지 알리기
        if (choosedAnswer == answerToggleNum) //선택한 넘버와 실제 정답 넘버가 같으면
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
    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
