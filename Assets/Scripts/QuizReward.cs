using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizReward : MonoBehaviour {

    /*쪽지 3개 부분*/
    GameObject[] reward;
    /*보상 캔디의 종이 부분*/
    GameObject candyPaper;
    /*보상 캔디 부분*/
    GameObject candyImg;
    /*클릭된 쪽지 이미지 이름*/
    int rewardNum = 0;

	// Use this for initialization
	void Start () {
        candyImg = GameObject.Find("candyImage");
        reward = new GameObject[3];
        for(int i=0; i<reward.Length; i++)
        {
            reward[i] = GameObject.Find("reward"+(i+1)); //reward1, 2, 3
        }

        candyPaper = GameObject.Find("candyPaper");
        candyPaper.SetActive(false); //처음에는 숨긴다.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * 랜덤하게 1~3 중 한 숫자를 뽑아 보상 캔디 개수를 지정한다.
     */
    /*public void OnClickReward()
    {
        //보상 캔디 개수를 넘겨줌
        ShowRewardCandy(Random.Range(1, 4));
    }*/

    public void OnClickReward1()
    {
        rewardNum = 1;
        //보상 캔디 개수를 넘겨줌
        ShowRewardCandy(Random.Range(1, 4));
    }

    public void OnClickReward2()
    {
        rewardNum = 2;
        //보상 캔디 개수를 넘겨줌
        ShowRewardCandy(Random.Range(1, 4));
    }

    public void OnClickReward3()
    {
        rewardNum = 3;
        //보상 캔디 개수를 넘겨줌
        ShowRewardCandy(Random.Range(1, 4));
    }

    /**
     * 보상 캔디 보여줌
     */
    public void ShowRewardCandy(int number)
    {
        //기존 보상 쪽지 3개를 없애고,
        for(int i=0; i<reward.Length; i++)
        {
            reward[i].SetActive(false);
        }

        candyPaper.SetActive(true);
        //해당 종이색을 맞춘다.
        candyPaper.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("quiz_reward/" + "reward" + rewardNum + "paper");
        //해당 캔디 수의 그림을 보여준다.
        candyImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("quiz_reward/" + "candy" + number);
        

        //문제를 푼 캐릭터에게 캔디수를 추가한다.
        GameData.GetCurrentCharacter().candy += number;
    }

    /**
     * 보상 캔디를 클릭 하면 다음 턴
     */
    public void OnClickCandy()
    {
        //다음 턴 넘기기
        GameData.TurnChange();
    }
}
