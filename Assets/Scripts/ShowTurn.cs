using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurn : MonoBehaviour {

    //순서 부분
    GameObject[] player;
    //순서 부분 캐릭터 썸네일
    GameObject thumbnail;

	GameObject arrow1;
	GameObject arrow2;
	GameObject arrow3;

    /*현재 캐릭터 이미지 (혈당 그래프 왼쪽위치)*/
    GameObject curCharImg;

	// Use this for initialization
	void Start () {
        //왼쪽 하단 캐릭터 세팅
        if (GameObject.Find("CharacterImage") != null)
        {
            curCharImg = GameObject.Find("CharacterImage");
            curCharImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_Char/" + GameData.GetCurrentPlayerName());
        }

        arrow1 = GameObject.Find ("p1TurnArrow");
		arrow2 = GameObject.Find ("p2TurnArrow");
		arrow3 = GameObject.Find ("p3TurnArrow");
        player = new GameObject[4];
        thumbnail = GameObject.Find("CurrentPlayerImage");
        //아래 일단 캐릭터 이름으로 파일명을 했는데, 썸네일이면 뒤에 GameData.GetCurrentCharacter().name + "Thumbnail" 이런식으로 파일명 줘도 괜찮을듯!
        thumbnail.GetComponent<Image>().sprite = Resources.Load<Sprite>("UiFrame/" + GameData.GetCurrentCharacter().name + "_turn"); 
        Debug.Log("현 플레이어: " + GameData.currentPlayer);
        //콘텐츠 로드
        LoadContents();
        //active setting
        SetActive();

        //썸네일 자리 옮기기
        SetPlace();
	}

    /**
     * 썸네일 이미지와 순서 이름 자리 조정
     * 일단 두 명만~
     */
    private void SetPlace()
    {
		switch (GameData.pStrList.Length) {
		case 2:
			arrow2.SetActive (false);
			break;
		case 3:
			arrow3.SetActive (false);
			break;
		default:
			break;
		}

		SetTextColor ();

        float yPos = 0;
        //현재 순서인 플레이어를 찾는다.
        for (int i=0; i<player.Length; i++)
        {
            //만약 현재 플레이어면,
            if (player[i].GetComponent<Text>().text.Equals(GameData.currentPlayer))
            {
                yPos = player[i].transform.localPosition.y;

                if (i == 1)
                {
					player[0].transform.localPosition = new Vector3(0, 413, 0);
                    thumbnail.transform.localPosition = new Vector3(0, player[i].transform.localPosition.y + 220, 0);
                    player[i].transform.localPosition = new Vector3(0, -125, 0);
                }
            }
        }

        
    }

    private void SetActive()
    {
        //해당 수 만큼만 active
        for(int i=0; i<GameData.playerCount; i++)
        {
            //active 해주고,
            player[i].SetActive(true);
            player[i].GetComponent<Text>().text = GameData.pStrList[i];
        }
    }

    private void LoadContents()
    {
        //player 1~4 찾기
        for (int i=0; i<4; i++)
        {
            player[i] = GameObject.Find("Player" + (i + 1));
            player[i].SetActive(false);
        }
    }

	private void SetTextColor() {
		for (int i=0; i<player.Length; i++)
		{
			//만약 현재 플레이어면,
			if (player [i].GetComponent<Text> ().text.Equals ("마리")) {
				player [i].GetComponent<Text> ().color = new Color32 (141, 81, 237, 255);
			} else if (player [i].GetComponent<Text> ().text.Equals ("매트")) {
				player [i].GetComponent<Text> ().color = new Color32 (95, 190, 33, 255);
			} else if (player [i].GetComponent<Text> ().text.Equals ("빅터")) {
				player [i].GetComponent<Text> ().color = new Color32 (27, 123, 236, 255);
			} else if (player [i].GetComponent<Text> ().text.Equals ("루시")) {
				player [i].GetComponent<Text> ().color = new Color32 (243, 49, 68, 255);
			}
		}
	}

    // Update is called once per frame
    void Update () {
		
	}
}
