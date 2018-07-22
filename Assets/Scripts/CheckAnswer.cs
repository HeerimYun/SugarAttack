using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAnswer : MonoBehaviour {

    float currentTime = 0;
    public float duraition = 5;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x == 1 && Input.GetMouseButtonDown(0))
        {
            
            //정답이면 보상 페이지로, 오답이면 다음으로 넘김
            if (QuizScene.isAnswer) //정답
            {
                //보상 씬으로 이동
                PageMove.OnClickCheckAnswerPanel();
            }
            else
            {
                //원래는 도서관으로 넘겨야 하나 아직 미완성이므로 턴 넘김
                GameData.TurnChange(); //턴 넘기기
            }
        }
	}
}
