using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenForCook : MonoBehaviour
{
    public GameManager gameManager;
    private SpriteRenderer _sr;
    public bool IsCooking { get; set; }
    
    public GameObject RamenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
        if (!GameManager.instance.IsGamming)
        {
            IsCooking = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!GameManager.instance.IsGamming)
        {
            IsCooking = false;
        }
        UpdateOvenColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter! >> " + collision.name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<DragScript>())
        {
            collision.GetComponent<DragScript>().initPosition();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.instance.IntoOven(this, collision);
        Debug.Log("exit! >> " + collision.name);
    }

    private void UpdateOvenColor()
    {
        //if (_isCooking)
        //{
        //    _sr.material.color = Color.red;
        //}
        //else
        //{
        //    _sr.material.color = Color.black;
        //}
    }
}
