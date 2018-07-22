using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    /*아이템 박스 부분*/
    GameObject bogunsil, candy, monsterCard;

    // Use this for initialization
    void Start () {
        SetItemBox();
	}

    /**
     * 아이템 부분 세팅
     */
    private void SetItemBox()
    {
        //아이템 부분 로드
        bogunsil = GameObject.Find("BogunsilCount");
        candy = GameObject.Find("CandyCount");
        monsterCard = GameObject.Find("MonsterCardCount");

        //현재 플레이어
        for (int i = 0; i < GameData.character.Length; i++)
        {
            if (GameData.character[i].kName.Equals(GameData.currentPlayer))
            {
                //텍스트 세팅
                bogunsil.GetComponent<Text>().text = "" + GameData.character[i].nurseCount;
                candy.GetComponent<Text>().text = "" + GameData.character[i].candy;
                monsterCard.GetComponent<Text>().text = "" + GameData.character[i].monsterCard;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
