using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/**
 * 룰렛 돌리기: 내가 돌리는 방향, 드래그 한 만큼 돌아감
 * 손을 뗀 이후에는 다시 돌릴 수 없고 자동으로 멈출 때까지 기다리기
 */
public class RouletteSpin : MonoBehaviour {
    //회전 속도
    float spinSpeed = 0;
    //멈춘 후 각도
    float rouletteAngle = 0;
    //버튼 눌린 상태
    bool spinBtnPress = false;
    //돌리기 버튼 객체
    Button spinBtn;
    //결과 텍스트
    Text rouletteResult;

	// Use this for initialization
	void Start () {
        spinBtn = GameObject.Find("roulette_btn").GetComponent<Button>();
        rouletteResult = GameObject.Find("roulette_result").GetComponent<Text>();
        rouletteResult.enabled = false; //처음엔 감출 것

    }
	
	// Update is called once per frame
	void Update () {
		//마우스로 드래그를 하면 그만큼의 힘 설정
        //왼쪽 버튼 누르면 판 움직임
        if (spinBtnPress)
        {
            spinSpeed = Random.Range(15.0f, 28.0f);
            spinBtnPress = false;
        }
        transform.Rotate(0, 0, spinSpeed); //원판 z축 rotating
        //spinSpeed *= 0.99f; //점점 속도 느리게 하기
        spinSpeed *= Random.Range(0.99f, 0.999f); //점점 속도 느리게 하기

        if (spinSpeed < 0.1 && spinSpeed > 0)
        {
            spinSpeed = 0; //룰렛을 멈추고

            if (transform.rotation.z % 10 == 0) // 딱 경계선인 경우
            {
                transform.Rotate(0, 0, (transform.rotation.z + 0.5f)); //조금만 움직여주기
            }

            //숫자가 얼마 나왔는지 나타내기
            //먼저 돌리기 글자를 없애고,
            GameObject.Find("roulette_spin_text").GetComponent<Image>().enabled = false;

            rouletteResult.enabled = true;
            rouletteResult.text = RouletteResult() + "";

            //숫자를 현재 캐릭터 이동에 반영
            GameData.GetCurrentCharacter().position += RouletteResult();

            //해당 칸에 따른 Scene으로 이동 하는 함수 호출
            PageMove.OnClickDice();
        }

    }

    /**
     * "돌리기" 버튼을 누르는 순간 동작
     */
    public void OnClickSpinBtn()
    {
        spinBtnPress = true;

        //한번 룰렛을 돌린 이후로는 또 돌릴 수 없도록 버튼 비활성화
        spinBtn.enabled = false;
    }

    /**
     *  룰렛 숫자 판정
     */
     public int RouletteResult()
    {
        int result = 0;

        rouletteAngle = transform.localEulerAngles.z;
        //Debug.Log("현재 룰렛 Z 값: " + rouletteAngle);

        if (rouletteAngle > 180)
        {
            rouletteAngle -= 180;
        }

        result = (int)(rouletteAngle / 30) + 1;

        return result;
    }
}
