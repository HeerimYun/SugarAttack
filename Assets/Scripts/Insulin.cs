using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 식사 후 인슐린 맞는 스크립트
 */
public class Insulin : MonoBehaviour {

    GameObject currentCharImg;

	// Use this for initialization
	void Start () {
        currentCharImg = GameObject.Find("Character");
        //혈당 그래프 왼쪽 작은 캐릭터 나타내기
        currentCharImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(GameData.currentPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
