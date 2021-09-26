using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RamenObject : MonoBehaviour
{

    public GameManager gameManager;
    private const float _burntTimeout = 5;
    private float _boilingTime;

    private bool isBurnt; //≈∫ ∞Õ ¿Œ¡ˆ?
    public bool IsBurnt { get { return isBurnt; } }

    public int Price { set; get; }

    private ArrayList cookingList= new ArrayList();
    readonly string WATER = "Water";
    readonly string NOODLE = "Noodle";
    readonly string SOUP_POWDER = "SoupPowder";
    public bool AddWater()
    {

        if (!IsBurnt 
            && cookingList.Count < 1
            && !cookingList.Contains(WATER))
        {
            cookingList.Add(WATER);
            GameObject waterPot = transform.GetChild(0).gameObject;
            waterPot.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }


    }
    public bool AddNoodle()
    {

        if (!IsBurnt
            && cookingList.Contains(WATER)
            && cookingList.Contains(SOUP_POWDER)
            && !cookingList.Contains(NOODLE))
        {
            cookingList.Add(NOODLE);

            GameObject waterPot = transform.GetChild(0).gameObject;
            waterPot.SetActive(false);
            GameObject redPot = transform.GetChild(1).gameObject;
            redPot.SetActive(false);
            GameObject noodlePot = transform.GetChild(2).gameObject;
            noodlePot.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool AddSoupPowder()
    {
        if (!IsBurnt 
            && cookingList.Contains(WATER) 
            && !cookingList.Contains(SOUP_POWDER))
        {
            cookingList.Add(SOUP_POWDER);
            GameObject waterPot = transform.GetChild(0).gameObject;
            waterPot.SetActive(false);
            GameObject noodlePot = transform.GetChild(2).gameObject;
            noodlePot.SetActive(false);
            GameObject SoupPot = transform.GetChild(1).gameObject;
            SoupPot.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }

    }
    bool _isDrag = false;
    private void OnMouseDown()
    {
        _isDrag = true;
    }
    private void OnMouseUp()
    {
        _isDrag = false;
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && _isDrag)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = worldPoint;
        }
    }
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.instance.RamenDragTo(this, collision);
        
    }

    void Start()
    {
        gameObject.SetActive(true);
        _boilingTime = _burntTimeout;
    }
    void Update()
    {
        _boilingTime -= Time.deltaTime;

        
        if (_boilingTime < 0)
        {
            isBurnt = true;
            GameObject BurntPot = transform.GetChild(4).gameObject;
            BurntPot.SetActive(true);
            Debug.Log("burnt!!!!: " + _boilingTime);
        }
    }
}
