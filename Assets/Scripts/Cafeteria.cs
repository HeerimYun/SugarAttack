using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * 급식실 도착 시 동작하는 스크립트
 */
public class Cafeteria : MonoBehaviour {

    //급식실 구름 이미지
    GameObject geupsicksil;
    //시간
    float currentTime = 0;
    //구름 이미지 지속 시간
    public int imgDuraition = 3;
    //함수 실행 여부
    //bool isActivated = false;
    //현재 순서 캐릭터
    GameObject currentChar;

	// Use this for initialization
	void Start () {
        //객체 load
        geupsicksil = GameObject.Find("Geupsicksil");
        currentChar = GameObject.Find("currentCharImg");
        currentChar.GetComponent<Image>().sprite = Resources.Load<Sprite>(GameData.GetCurrentPlayerName()); //현재 차례 플레이어 이미지 넣기
	}

    /**
     * 급식실 구름 이미지 띄웠다가 없애는 함수
     */
    private void ShowTextImg()
    {
        SceneManager.LoadScene(11);
    }

    // Update is called once per frame
    void Update () {
        currentTime += Time.deltaTime;
        if (currentTime > imgDuraition)
        {
            ShowTextImg();
        }
	}
}
