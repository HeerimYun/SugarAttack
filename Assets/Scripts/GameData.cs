 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 게임 관련 데이터 입/출력 스크립트
 */
public class GameData : MonoBehaviour {

    public static GameData Instance; //single tone pattern 이용(:객체 하나만 생성)

    //보드 정보: 총 54칸
    public static string[] board = new string[54] {
    "출발", "몬스터", "식사", "퀴즈", "몬스터", "사물함", "퀴즈", "운동",
    "상황", "사물함", "몬스터","간식","퀴즈","몬스터","식사","급식","퀴즈","몬스터",
    "찬스","사물함", "몬스터","운동","사물함","몬스터","상황","실험실","몬스터","퀴즈","급식"
    ,"찬스", "사물함","퀴즈","몬스터","운동","몬스터","사물함","퀴즈","식사","퀴즈","운동",
    "급식","상황","찬스","몬스터","퀴즈","몬스터","간식","실험실","운동","몬스터","퀴즈","도착",
    "도서관","보건실"};

    //*************************************각 칸 별 정보*************************************//

    //급식실 배열
    string[] cafeteriaName = new string[23] { "쫄면 (1인분)", "샌드위치 (1개)", "라면 (1봉지)", "국수 (1인분)", "피자 (1조각)", "햄버거 (1개)", "시리얼 (1인분)", "우동 (1그릇)", "파스타 (1인분)", "만두 (100g)", "짜장면 (반그릇-어린이)", "메밀국수 (반그릇-어린이용)", "후렌치후라이 (100g)", "콘샐러드", "팥밥 (1인분)", "잡곡밥 (1공기)", "백미 (1공기)", "흰죽 (1인분)", "쌀국수 (1그릇)", "현미밥 (1공기)", "보리밥", "흰 바게트 빵", "흰 빵 (밀가루)" };
    int[] cafeteriaCa = new int[23] { 43, 27, 56, 40, 26, 32, 27, 47, 52, 20, 49, 52, 35, 23, 51, 73, 53, 44, 37, 32, 44, 16, 14 };

    //식사 칸 배열
    string[] mealName = new string[16] { "감 (1개)", "귤 (3개)", "딸기 (1접시)", "망고 (1개)", "멜론 (1개)", "복숭아 (3개)", "사과 (2개)", "오렌지 (2개)", "파인애플 (반 개)", "포도 (1컵)", "수박 (1 큰 반달조각)", "자몽 (3개)", "옥수수 (1개)", "삶은 감자 (1개)", "삶은 고구마 (1개)", "단호박 (1개)" };
    int[] mealCa = new int[16] { 31, 27, 27, 35, 45, 27, 38, 30, 30, 28, 43, 36, 30, 20, 28, 14 };

    //간식 칸 배열
    string[] snackName = new string[12] { "도넛 (1개)", "쿠키 (1개)", "스낵과자 (1개)", "핫도그 (1개)", "카스텔라 (1개)", "초코파이 (1개)", "팥빵 (1개)", "찹쌀떡 (1개)", "초콜릿 (1개)", "아이스크림 (1개)", "콜라", "포도주스" };
    int[] snackCa = new int[12] { 23, 10, 18, 15, 31, 23, 45, 25, 24, 13, 25, 25 };

    //운동 칸 배열
    string[] exerciseName = new string[13] { "느리게 걷기", "빠르게 걷기", "테니스(혼자)", "테니스(같이)", "자전거타기(느리게)", "자전거타기(보통)", "자전거타기(빠르게)", "자전거타기(격하게)", "배드민턴", "달리기", "계단 오르내리기", "체조", "수영" };
    int[] exerciseCa = new int[13] { 17, 28, 28, 20, 17, 25, 28, 40, 20, 40, 19, 11, 45 };

    //몬스터 칸 배열
    int[] monsterScore = new int[18] { 5, 10, 20, 10, 15, 20, 5, 10, 25, 5, 20, 25, 5, 15, 20, 5, 15, 25 };
    string[] monsterName = new string[18] { "카곤", "카곤", "카곤", "글루", "글루", "글루", "케톤", "케톤", "케톤", "고이드", "고이드", "고이드", "에피", "에피", "에피", "노르", "노르", "노르" };
    int[] maxCandy = new int[18] { 1, 2, 4, 2, 3, 4, 1, 2, 5, 1, 5, 5, 1, 3, 4, 1, 3, 5 };

    //실험
    int[] experiment = new int[2] { 0, 2 };

    //상황
    public static string[] situation = new string[18] { "몬스터를 잡기 위해 운동장을 뛰었더니 혈당이 내려갔어요.", "학교 옥상으로 도망간 몬스터를 잡기 위해 계단을 올라갔더니 혈당이 내려갔어요.", "학교 수영장으로 도망간 몬스터를 잡기 위해 수영을 했더니 혈당이 내려갔어요.", "숨어 있는 몬스터를 찾으러 다녔더니 혈당이 내려갔어요.", "친구의 간식을 훔쳐 달아나는 몬스터를 잡기 위해 자전거를 탔더니 혈당이 내려갔어요.", "친구의 초콜릿 2개를 빼앗아 먹었더니 혈당이 올라갔어요.", "책상 위에 있는 도넛 1개를 먹었더니 혈당이 올라갔어요.", "가방에 있던 초코파이 2개를 모두 먹었더니 혈당이 올라갔어요.", "시리얼을 먹고 인슐린 주사 맞는 걸 깜빡했더니 혈당이 올라갔어요.", "밥을 먹지 않고 아이스크림 1개와 팥빵 1개를 많이 먹었더니 혈당이 올라갔어요.", "포도당 캔디 1개를 떨어뜨려버렸어요.", "포도당 캔디 2개를 떨어뜨려버렸어요.", "포도당 캔디 1개를 다른 플레이어에게 선물해주세요.", "가지고 있는 아이템(꿀/주스/요구르트) 중 1개를 선택하여 다른 플레이어에게 선물해주세요.", "저혈당으로 혈당이 내려갔어요. 보건실로 이동해야해요.", "고혈당으로 혈당이 올라갔어요. 보건실로 이동해야해요.", "가지고 있는 인슐린이 상했어요.", "혈당체크를 깜빡했어요. 다음 순서까지 혈당을 볼 수 없어요." };
    public static int[] situationVal = new int[18] { -40, -19, -45, -28, -28, 48, 23, 46, 27, 58, 0, 0, 0, 0, 0, 0, 0, 0 };

    //비밀의 사물함
    string[] lockeroom = new string[12] { "주스 1컵을 발견했어요.", "주스 2컵을 발견했어요.", "주스 3컵을 발견했어요.", "꿀 1스푼을 발견했어요.", "꿀 2스푼을 발견했어요.", "꿀 3스푼을 발견했어요.", "요구르트 1개를 발견했어요.", "요구르트 2개를 발견했어요.", "요구르트 3개를 발견했어요.", "포도당 캔디 1개를 발견했어요.", "포도당 캔디 2개를 발견했어요.", "포도당 캔디 3개를 발견했어요." };

    //퀴즈
    public static string[] quizQuestion = new string[2] { "매일 똑같은 부위에\n 주사를 맞아야해요!", "매일 같은 시간에\n 식사를 하는 게 좋아요!" };
    public static bool[] quizAnswer = new bool[2] {false, true};
    public static int curQuiz = 0;

    //음식 - 임시로 만든 목록
    public static string[] kFoodName = {"샌드위치", "우동" , "짬뽕", "피자"}; //화면에 뜰 글자
    public static string[] foodName = {"sandwich","udong","jjamppong", "pizza"}; //각 음식에 대한 파일명
    public static int curFood = 0;
    public static int[] foodSugar = { 27, 47, 43, 26};

    //캐릭터 변수
    public static Character[] character;
    public const int LUCY = 0;
    public const int MARIE = 1;
    public const int MATT = 2;
    public const int VICTOR = 3;

    public static bool isCharSelected = false;
    //********진행 관련 변수*********//
    //게임 참여중인 플레이어 리스트
    public static string[] playerList;
    //플레이어 리스트 한글이름
    public static string[] pStrList;
    //현재 플레이어
    public static string currentPlayer;
    //플레이어 수
    public static int playerCount;
    //monster 카드 배열
    Monster[] monster;

    //시나리오 주사위 배열
    public static int[] scenarioDice = new int[8] {6, 2, 2, 6, 6, 4, 1, 3};
    public static int currentDice = 0;

    //인스턴스 없을 시 생성
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Use this for initialization
    void Start () {
        //SetCharacters(); //캐릭터 초기화 -> charorder에서 지정할 것
        SetMonsters();
	}

    /**
     * 몬스터 초기화 메서드
     */
    private void SetMonsters()
    {
        monster = new Monster[18];
        for(int i=0; i<monster.Length; i++)
        {
            monster[i] = new Monster(monsterName[i], monsterScore[i], maxCandy[i]);
        }
    }

    /**
     * 캐릭터 초기화 메서드
     */
    private void SetCharacters()
    {
        character = new Character[playerList.Length];

        for (int i=0; i<character.Length; i++)
        {
            character[i] = new Character("", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, false, 0);
        }
    }

    // Update is called once per frame
    void Update () {
	}

    /**
     * 현재 차례인 플레이어의 이름
     */
    public static void CheckCurrent()
    {
        for(int i=0; i<character.Length; i++)
        {
            if (character[i].isCurrent)
                currentPlayer = character[i].kName;
        }
    }

    /**
     * 캐릭터 객체 생성하는 메서드
     * CharOrder에서 호출됨
     */
    public static void MakeCharacterList()
    {
        string kName = "";
        //캐릭터 만큼 배열 생성
        character = new Character[playerList.Length];

        //선택한 플레이어 목록만큼 캐릭터 객체 생성
        for (int i=0; i<character.Length; i++)
        {
            //한글 이름 결정
            if (playerList[i].Equals("Lucy"))
                kName = "루시";
            else if (playerList[i].Equals("Marie"))
                kName = "마리";
            else if (playerList[i].Equals("Matt"))
                kName = "매트";
            else
                kName = "빅터";

            character[i] = new Character(playerList[i], kName,"", i, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, false, 0);
        }
        Debug.Log("GameData에 캐릭터 정보 저장 완료...");

        //한글이름 배열도 저장
        MakeCharStrList();
        character[0].isCurrent = true; //맨 처음 플레이어를 current로 설정
    }

    private static void MakeCharStrList()
    {
        string strName = "";
        pStrList = new string[playerCount];
        for(int i=0; i<pStrList.Length; i++)
        {
            if (character[i].name.Equals("Lucy"))
            {
                strName = "루시";
            }
            else if(character[i].name.Equals("Marie"))
            {
                strName = "마리";
            }
            else if(character[i].name.Equals("Matt"))
            {
                strName = "매트";
            }
            else
            {
                strName = "빅터";
            }
            pStrList[i] = strName;
        }

        //currentPlayer = character[0].kName; //맨 처음 선수를 current로 설정
    }

    public static string GetCurrentPlayerName()
    {
        string current = "";
        for (int i=0; i<character.Length; i++)
        {
            if(character[i].kName.Equals(currentPlayer))
            {
                current = character[i].name;
            }
        }
        return current;
    }

    public static int GetCurrentPlayerBlood()
    {
        int blood = 0;

        for (int i = 0; i < character.Length; i++)
        {
            if (character[i].kName.Equals(currentPlayer))
            {
                blood = character[i].bloodSugar;
            }
        }

        return blood;
    }

    /**
     * 현재 플레이어 객체 반환 메서드
     */
    public static Character GetCurrentCharacter()
    {
        Character player = null;

        for (int i=0; i<character.Length; i++)
        {
            if(character[i].kName.Equals(currentPlayer))
            {
                player = character[i];
            }
        }

        return player;
    }

    /**
     * 턴을 넘기는 메서드
     */
    public static void TurnChange()
    {
        int currentIndex = 0;
        //isCurrent를 바꿔준다.
        //현재 플레이어 리스트를 검사후, current를 다음 인덱스 캐릭터로 바꾼다.
        for (int i=0; i<playerList.Length; i++)
        {
            if (character[i].isCurrent)
                currentIndex = i;
        }

        currentIndex++;
        currentIndex = currentIndex % playerCount;
        Debug.Log("currentIndex : " + currentIndex);

        for (int i=0; i<playerList.Length; i++)
        {
            character[i].isCurrent = false;
        }

        character[currentIndex].isCurrent = true;



        SceneManager.LoadScene(6); //룰렛 돌리는 화면으로 보내기
    }
}




public class Character
{
    /*이름*/
    public string name;
    /*한글 이름*/
    public string kName;
    /*능력*/
    public string ability;
    /*순서*/
    public int order;
    /*점수*/
    public int score;
    /*아이템*/
    public int honey, juice, yogurt, candy, monsterCard;
    /*위치*/
    public int position;
    /*혈당*/
    public int bloodSugar;
    /*이상 상태 걸린 횟수*/
    public int highOrLowCount;
    /*보건실 도착 횟수*/
    public int nurseCount;
    /*현재 순서인가?*/
    public bool isCurrent;
    /*입력 혈당*/
    public int inputInsulin;

    //생성자
    public Character (string name, string kName , string ability, int order, int score, int honey, int juice, int yogurt, int candy, 
        int monsterCard, int position, int bloodSugar, int highOrLowCount, int nurserCount, bool isCurrent, int inputInsulin)
    {
        this.name = name;
        this.kName = kName;
        this.ability = ability;
        this.order = order;
        this.score = score;
        this.honey = honey;
        this.juice = juice;
        this.yogurt = yogurt;
        this.candy = candy;
        this.monsterCard = monsterCard;
        this.position= position;
        this.bloodSugar= bloodSugar;
        this.highOrLowCount= highOrLowCount;
        this.nurseCount = nurserCount;
        this.isCurrent = isCurrent;
        this.inputInsulin = inputInsulin;
    }   
}

public class Monster
{
    /*몬스터 이름*/
    public string name;
    /*몬스터 점수*/
    public int score;
    /*최대 캔디 개수*/
    public int candy;

    //생성자
    public Monster(string name, int score, int candy)
    {
        this.name = name;
        this.score = score;
        this.candy = candy;
    }
}