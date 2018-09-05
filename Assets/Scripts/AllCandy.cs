using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 캔디 주는 화면 3초간 유지
 * 5초는 명시되어 있지 않아 임의로 정했습니다.
*/
public class AllCandy : MonoBehaviour {

    /*화면 유지 시간*/
    public int duraition = 3;
    float currentTime = 0;

	// Use this for initialization
	void Start () {
		//참여중인 캐릭터 모두의 candy 5개씩 증가
        for(int i=0; i<GameData.character.Length; i++)
        {
            GameData.character[i].candy += 5;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //시간 흐르게 한다.
        currentTime += Time.deltaTime;
        
        //시간 지나면 씬 넘기기
        if(currentTime > duraition)
        {
            //startTurn으로 보냄 (프로토타입)
            //SceneManager.LoadScene(6);

            //1.5_Roulette으로 보냄
            SceneManager.LoadScene(7);
        }
	}
}
