using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScene2 : MonoBehaviour {

    float currentTime = 0;

    GameObject question; //문제 부분
    public static bool isAnswer = false; //정답 여부
    bool playerAnswer = false; //입력 받은 정답

    GameObject[] answer = new GameObject[4]; //선택지
    GameObject checkAnswerBtn; //정답 확인 버튼

    //answer panel
    GameObject answerResult;
    GameObject answerImg; //현재 캐릭터 이미지 공간
    GameObject isTrueOfFalse; //맞았어요! or 틀렸어요!

    bool isTimeToMove = false;

    public int answerToggleNum = 0; //답이 될 토글 버튼 넘버, 1 부터 4 중 하나가 될 것임 
    public int choosedAnswer = 0; //사용자가 정답으로 선택하여 클릭한 토글의 번호

    // Use this for initialization
    void Start()
    {
        //로딩
        question = GameObject.Find("QuizText");
        for (int i=0; i<answer.Length; i++) //선택지 4개 토글 버튼
        {
            answer[i] = GameObject.Find("AnswerToggle"+(i + 1));
        }
        checkAnswerBtn = GameObject.Find("CheckAnswerBtn");
        answerResult = GameObject.Find("CheckAnswer");
        answerImg = GameObject.Find("Character");
        isTrueOfFalse = GameObject.Find("TrueFalse");

        //퀴즈 띄우기
        question.GetComponent<Text>().text = GameData.quizQuestion[GameData.curQuiz];
        //GameData.curQuiz++; //다음 퀴즈로 이동

        //선택지에 그림 및 텍스트 띄우기


        //답이 될 버튼 한 개 무작위로 선택
        answerToggleNum = Random.Range(1, 4);

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
     */
    public void ChooseAnswer()
    {
        //선택완료 버튼 활성화
        checkAnswerBtn.GetComponent<Button>().interactable = true;

        //선택한 토글에 따라 선택한 번호 저장 (매번 클릭 시 바뀜)
        for (int i=0; i<answer.Length; i++)
        {
            if (answer[i].GetComponent<Toggle>().isOn)
            {
                choosedAnswer = i + 1; //토글이 켜져 있으면 사용자가 해당 번호를 답으로 선택한 것
                Debug.Log("답으로 체크된 토글 번호: " + choosedAnswer);
            }
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
