using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 혈당 그래프 표시할 스크립트
 */
public class BloodGraph : MonoBehaviour {

    GameObject graph;

	// Use this for initialization
	void Start () {
        graph = GameObject.Find("GraphText");
        //현재 순서 플레이어의 혈당 나타내기
        //graph.GetComponent<Text>().text = "현재 혈당: " + GameData.GetCurrentPlayerBlood();
    }
	
	// Update is called once per frame
	void Update () {
        //현재 순서 플레이어의 혈당 나타내기
        if (graph != null)
        {
            graph.GetComponent<Text>().text = "현재 혈당: " + GameData.GetCurrentPlayerBlood();
        }
	}
}
