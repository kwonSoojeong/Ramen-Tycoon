using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour
    
//, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("pointer Down");
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Debug.Log("Begin Drag");
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Debug.Log("Drag~");
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Debug.Log("End Drag");
    //}

    //private RectTransform m_DraggingPlane;


    //public void OnDrag(PointerEventData eventData)
    //{
    //    m_DraggingPlane.position = Input.mousePosition;
    //    Debug.Log(">> Rect positon >> " + m_DraggingPlane.position);
    //    Debug.Log(">> transform positon >> " + transform.position);
    //}

    Vector3 _initPoint;
    // Start is called before the first frame update
    void Start()
    {
        //m_DraggingPlane = transform as RectTransform;
        Debug.Log(">> start transform positon >> " + transform.position);
        _initPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isDrag = false;
    private void OnMouseDown()
    {
        isDrag = true;
        //Debug.Log("down");
    }
    
    private void OnMouseDrag()
    {
        //Debug.Log("Drag >>> " + name);
        
        if (Input.GetMouseButton(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = worldPoint;
            //Debug.Log(">> >> transform positon >> " + transform.position);
        }
    }
    private void OnMouseUp()
    {
        isDrag = false;
        //Debug.Log("up");
    }

    public void initPosition()
    {
        transform.position = _initPoint;
    }
}
