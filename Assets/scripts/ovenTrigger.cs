using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovenTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        Debug.Log("Enter! >> " + collision.name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<DragScript>().initPosition();
        
        if(collision.name.Equals("Water"))
        {
            Debug.Log("water >> " + collision.name);
        }
        else if (collision.name.Equals("Ramen"))
        {
            Debug.Log("ramen >> " + collision.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Water"))
        {
            Debug.Log("water >> " + collision.name);
            //扼搁 按力 积己
        }
        else if (collision.name.Equals("Ramen"))
        {
            Debug.Log("ramen >> " + collision.name);
        }
    }
}
