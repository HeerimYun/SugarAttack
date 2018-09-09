using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //인벤토리 토글 버튼
    Toggle inven_btn;

    //가방 내용 (펼쳐진 인벤토리 창)
    GameObject inventory;

    //알림창에 뜰 숫자들
    public int item_count = 0;
    public int juice_count = 0;
    public int honey_count = 0;
    public int yogurt_count = 0;
    public int candy_count = 0;

    // 주스, 꿀, 요거트, 캔디 아이템 버튼
    Button[] itemBtns = new Button[4];

    //사용하기 버튼
    Button useItemBtn;

    // 아이템 사용 팝업 창
    GameObject itemPopup;

    // Use this for initialization
    void Start () {
        inven_btn = GameObject.Find("Bag_toggle").GetComponent<Toggle>();
        inventory = GameObject.Find("Inventory_content");

        //디자인을 위해 텍스트를 Inspector창에서 아이템 개수 숫자를 바꿀 수 있도록 임시로 작성한 코드
        GameObject.Find("itemNum").GetComponent<Text>().text = "" + item_count;
        GameObject.Find("juiceNum").GetComponent<Text>().text = "" + juice_count;
        GameObject.Find("honeyNum").GetComponent<Text>().text = "" + honey_count;
        GameObject.Find("yogurtNum").GetComponent<Text>().text = "" + yogurt_count;
        GameObject.Find("candyNum").GetComponent<Text>().text = "" + candy_count;

        itemBtns[0] = GameObject.Find("JuiceBtn").GetComponent<Button>();
        itemBtns[1] = GameObject.Find("HoneyBtn").GetComponent<Button>();
        itemBtns[2] = GameObject.Find("YogurtBtn").GetComponent<Button>();
        itemBtns[3] = GameObject.Find("CandyBtn").GetComponent<Button>();

        itemPopup = GameObject.Find("Item_using");

        useItemBtn = GameObject.Find("useItemBtn").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * 가방 버튼 클릭 마다 호출
     */
    public void OnClickBagToggle()
    {
        //켜져있으면 가방 닫고, 꺼져있으면 열 것
        if (inven_btn.isOn)
        {
            CloseBag();
        }
        else
        {
            OpenBag();
        }
    }

    /**
     * 가방을 여는 함수
     */
    public void OpenBag()
    {
        //인벤창을 보이게 한다.
        inventory.transform.localScale = new Vector3(1, 1, 1);
    }

    /**
     * 가방을 닫는 함수
     */
    public void CloseBag()
    {
        //인벤창을 안 보이게 한다.
        inventory.transform.localScale = new Vector3(0, 1, 1);

        if (itemPopup.transform.localScale.x > 0)
        {
            itemPopup.transform.localScale = new Vector3(0, 1, 1);
        }
    }

    /**
     * 아이템 버튼을 누르면 호출되는 함수
     */
    public void OnClickItemBtns()
    {
        if (itemPopup.transform.localScale.x < 1) //팝업이 없는 상태
        {
            itemPopup.transform.localScale = new Vector3(1, 1, 1); //팝업을 연다.
        }
    }

    public void OnClickUseBtn()
    {
        //창을 닫는다.
        itemPopup.transform.localScale = new Vector3(0, 1, 1);
    }
}
