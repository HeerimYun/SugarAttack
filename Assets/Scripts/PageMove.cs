using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * 페이지 이동하는 함수들이 있는 스크립트
 */
public class PageMove : MonoBehaviour {
    public static PageMove Instance;

    private void Start()
    {
        /**
         * 일시정지 메뉴가 있을경우에만 기능 작동 (Null 방지)
         */
        if(GameObject.Find("PauseMenu") != null)
        {
            GameObject.Find("PauseMenu").transform.localScale = new Vector3(0, 0, 0);
        }
        
    }

    // Scene: 0.1_WaitingRoom
    /**
     * 게임 설명 버튼을 누를 때, 게임 설명화면으로 넘어감
     */
    /*public void OnClickHowToPlayBtn()
    {
        SceneManager.LoadScene(7);
    }*/
    /**
     * 게임 시작을 누를 때, 넘어감
     */
    public void OnClickGamePlayBtn()
    {
        SceneManager.LoadScene(2);
    }
    /**
     * 설정 버튼 누를 때
     */
     public void OnClickSettingBtn()
    {
        //SceneManager.LoadScene(8);
        OnClickPauseBtn();
    }

    // Scene: 1.0_IntroAnimation
    /**
     * 스킵 버튼 누를 때
     */
     public void OnClickSkipBtn()
    {
        SceneManager.LoadScene(3);
    }

    // Scene: 1.1_CharSelect
    /**
     * 선택 완료 버튼 누를 때
     */
    public void OnClickSelectDoneBtn()
    {
        SceneManager.LoadScene(4);
    }

    // Scene: 1.2_CharOrder
    /**
     * 선택 완료 버튼 누를 때
     */
    public void OnClickOkBtn()
    {
        SceneManager.LoadScene(5);
    }

    // Scene: 1.3_InsulinInput
    /**
     * 선택 완료 버튼 누를 때
     */
    public static void OnClickInputDoneBtn()
    {
        //SceneManager.LoadScene(6);
        SceneManager.LoadScene(22); //1.4_allCandy로 이동
    }

    // Scene: 1.4_StartTurn
    /**
     * 다음 버튼 누를 때
     */
    /*public void OnClickInputDoneBtn()
    {
        //SceneManager.LoadScene();
    }*/

    // Scene: 2.a_GameRule
    // Scene: 3.0_GameSettings
    /**
     * 돌아가기 버튼 누를 때
     */
    public void OnClickToWaitRoomBtn()
    {
		SceneManager.LoadScene(1);
    }

    /**
     * 일시정지 버튼을 누를 경우 오디오 세팅 박스가 나타남
     */
    public void OnClickPauseBtn()
    {
        //GameObject.Find("PauseMenu").transform.localPosition = new Vector3(0, -31.520f, 1);
        GameObject.Find("PauseMenu").transform.localScale = new Vector3(1, 1, 1);
    }

    /**
     * X 버튼을 누를 경우 오디오 세팅 박스가 닫힘
     */
    public void OnClickCloseBtn()
    {
        GameObject.Find("PauseMenu").transform.localScale = new Vector3(0, 0, 0);
    }

    /**
     * 그만하기 버튼을 누를 경우 오디오 세팅 박스가 닫힘
     */
    public void OnClickQuitBtn()
    {
        SceneManager.LoadScene(1);
    }

    public static void OnClickCheckAnswerPanel()
    {
        SceneManager.LoadScene(14); //퀴즈 보상 Scene으로 도착
    }

    public static void OnClickDice()
    {
        //해당 칸의 상황으로 보내기
        //식사칸일 경우
        if (GameData.board[GameData.GetCurrentCharacter().position].Equals("식사"))
        {
            SceneManager.LoadScene(11); //식사 칸으로 이동
            Debug.Log("식사 칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("몬스터"))
        {
            Debug.Log("몬스터 칸에 도착!");
        }
        else if(GameData.board[GameData.GetCurrentCharacter().position].Equals("퀴즈"))
        {
            SceneManager.LoadScene(13); //퀴즈 칸으로 이동
            Debug.Log("퀴즈칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("상황"))
        {
            SceneManager.LoadScene(16);
            Debug.Log("상황칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("사물함"))
        {
            Debug.Log("사물함칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("운동"))
        {
            Debug.Log("운동칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("주사"))
        {
            Debug.Log("주사칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("간식"))
        {
            Debug.Log("간식칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("실험실"))
        {
            Debug.Log("실험실칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("도서관"))
        {
            Debug.Log("도서관칸에 도착!");
        }
        else if (GameData.board[GameData.GetCurrentCharacter().position].Equals("급식"))
        {
            SceneManager.LoadScene(11); //임시로 식사로 보냄
            Debug.Log("급식칸에 도착!");
        }
        else
        {
            Debug.Log("도착!");
        }
    }
}

//깃 연동 테스트용 주석... 지워도 무방함
//testtest