using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenTouch : MonoBehaviour {

    /**
     * 맨 처음 로딩화면에서 화면 터치시 다음으로 넘어가기
     * 테스트용 함수임
     */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1); //대기실로 이동
        }
    }

}
