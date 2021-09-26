using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour
{
    Vector3 _initPoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(">> start gameobject >> " + gameObject);
        _initPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool _isDrag = false;
    private void OnMouseDown()
    {
        _isDrag = true;
    }
    
    private void OnMouseDrag()
    {        
        if (Input.GetMouseButton(0) && _isDrag && GameManager.instance.IsGamming)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = worldPoint;
            //Debug.Log(">> >> transform positon >> " + transform.position);
            //최상위.드래그끝(자가자신);
        }
    }
    private void OnMouseUp()
    {
        _isDrag = false;
    }

    public void initPosition()
    {
        transform.position = _initPoint;
    }
}
