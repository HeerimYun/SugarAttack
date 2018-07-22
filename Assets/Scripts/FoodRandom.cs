using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 음식 랜덤으로 드러나는 스크립트
 */
public class FoodRandom : MonoBehaviour {

    GameObject foodImage;
    GameObject foodText;
	GameObject characterImg;

    // Use this for initialization
    void Start () {
		//character setting
		characterImg = GameObject.Find("CharacterImage");
		characterImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + GameData.GetCurrentPlayerName());

        //음식 이미지
        foodImage = GameObject.Find("FoodImage");
        //사진 로드 - resources 에 sandwich, jjamppong 파일 두 개 넣으면 작동할 것임
        foodImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("cafeteria/food/" + GameData.foodName[GameData.curFood]); 

        //음식 글자
        foodText = GameObject.Find("TargetName");
        foodText.GetComponent<Text>().text = GameData.kFoodName[GameData.curFood];
        Debug.Log("현재 음식: "+GameData.kFoodName[GameData.curFood]);
       
        //혈당 올리기
        GameData.GetCurrentCharacter().bloodSugar += GameData.foodSugar[GameData.curFood];

        //음식 다음턴으로 넘기기
        GameData.curFood++;
        GameData.curFood = GameData.curFood % GameData.kFoodName.Length;

    }

    // Update is called once per frame
    void Update () {

	}
}
