using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class TopBar : MonoBehaviour
{
    private int days = 0;
    public Text testDay { get; set; }

    public GameObject storeBtnObj;
    public GameObject backBtnObj;
    public GameObject startBtnObj;

    public GameObject storeSet;
    public GameObject cookingSet;


    // Start is called before the first frame update
        void Start()
    {
        loadDays();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void OnClickStore()
    {
        storeBtnObj.SetActive(false);
        backBtnObj.SetActive(true);

        storeSet.SetActive(true);
        cookingSet.SetActive(false);
        Debug.Log("Clicked Store.");
    }

    public void OnClickBack()
    {
        storeBtnObj.SetActive(true);
        backBtnObj.SetActive(false);

        storeSet.SetActive(false);
        cookingSet.SetActive(true);
        Debug.Log("Clicked Back. go to cooking.");
    }

    public void OnClickStartBtn()
    {
        startBtnObj.SetActive(false);
        storeBtnObj.SetActive(false);
        backBtnObj.SetActive(false);
        // 일시정지버튼이 필요할까?

        storeSet.SetActive(false);
        cookingSet.SetActive(true);

        //게임메니저한테 게임 시작을 알림.
        GameManager.instance.IsGamming = true;
    }

    public void IncreaseDays()
    {
        days++;
        Debug.Log("IncreaseDays >> " + days);
    }

    public void loadDays()
    {
        Debug.Log("loadDays >> " + days);
    }
}
