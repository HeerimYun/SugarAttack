using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 1.5_StartTurn 씬에 있는 turnImage에 붙어있는 스크립트
 */
public class TurnImage : MonoBehaviour {
    //턴 이미지
    GameObject turnImg;

    //이미지 보이는 시간
    public float duration = 3;
    float currentTime = 0;

	// Use this for initialization
	void Start () {
        turnImg = GameObject.Find("TurnImage");
        
        //Debug.Log("턴이미지 파일명:"+GameData.GetCurrentCharacter().name);
        //처음에는 현재 순서의 플레이어 이미지를 띄운다.
        turnImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("turn/" + GameData.GetCurrentCharacter().name + "_turn");
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        //3초가 지나면
        if (currentTime > duration)
        {
            //이미지를 안보이게 한다.
            turnImg.SetActive(false);
        }
	}
}
