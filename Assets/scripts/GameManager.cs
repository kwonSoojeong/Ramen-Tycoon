using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject timeRemainGameObject;
    private float timeRemaining;
    public GameObject RamenPrefab;
    public bool IsGamming { get; set; }

    
    private GameObject[] _ramenArray = new GameObject[4];

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 60;
        IsGamming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGamming)
        {
            timeRemaining -= Time.deltaTime;
            //Text Time update.
            timeRemainGameObject.GetComponent<UnityEngine.UI.Text>().text = timeRemaining.ToString();
            //Debug.Log("===========> timeRemaining" + timeRemaining);
        }
        if (timeRemaining < 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        //게임 시간이 끝날때.
        IsGamming = false;
        timeRemainGameObject.GetComponent<UnityEngine.UI.Text>().text = "GAME OVER";
        timeRemaining = 60;
    }

    public void IntoOven(OvenForCook oven, Collider2D collision)
    {
        
        int index = 0;
        if (oven.name.Equals("Circle1"))
        {
            index = 0;
        }
        else if (oven.name.Equals("Circle2"))
        {
            index = 1;
        }
        else if (oven.name.Equals("Circle3"))
        {
            index = 2;
        }
        else if (oven.name.Equals("Circle4"))
        {
            index = 3;
        }
        
        

        if (collision.name.Equals("Water") && !oven.IsCooking /*&& _ramenObject == null*/)
        {

            Debug.Log("water exit >> " + collision.name);
            oven.IsCooking = true;
            //라면 오브젝트 생성
            GameObject ramenObject = Instantiate(RamenPrefab, oven.transform.position, Quaternion.identity);
            
            bool result = ramenObject.GetComponent<RamenObject>().AddWater();
            if (!result)
            {
                Destroy(ramenObject);
                oven.IsCooking = false;
            }
            else
            {
                ramenObject.SetActive(true);
                _ramenArray[index] = ramenObject;
            }
        }
        else if (collision.name.Equals("SoupPowder") && oven.IsCooking /*&& _ramenObject != null)*/)
        {
            _ramenArray[index].GetComponent<RamenObject>().AddSoupPowder();
            Debug.Log("++++ 라면 스프 +++++");
        }
        else if (collision.name.Equals("Noodle") && oven.IsCooking /*&& _ramenObject != null*/)
        {
            _ramenArray[index].GetComponent<RamenObject>().AddNoodle();
            Debug.Log("++++ 라면 면 +++++");
        }
    }


    public void RamenDragTo(RamenObject ramenObject, Collider2D collision)
    {
        // 쓰레기통
        // 손님
        //라면 버리라고 말해줘야하는데...

        if (collision.name.Equals("TrashCan"))
        {
            for (int index = 0; index < 4; index++)
            {
                if (_ramenArray[index].Equals(ramenObject.gameObject))
                {
                    
                    Destroy(_ramenArray[index]);
                    //인덱스에따라 오븐찾아서 오븐에 iscook = false로 바꿔야함.
                }
            }

        }
        if (collision.name.Equals("Guest") && !ramenObject.IsBurnt)
        {
            GameObject waterPot = ramenObject.transform.GetChild(0).gameObject;
            waterPot.SetActive(false);
            GameObject SoupPot = ramenObject.transform.GetChild(1).gameObject;
            SoupPot.SetActive(false);
            GameObject noodlePot = ramenObject.transform.GetChild(2).gameObject;
            noodlePot.SetActive(false);
            GameObject chapstickPot = ramenObject.transform.GetChild(3).gameObject;
            chapstickPot.SetActive(true);
        }
    }
}
