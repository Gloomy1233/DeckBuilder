using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    public Vector3 StartingObjectPosition;
    public bool clicker=false,notScrollRect;
    public GameObject parent,content;
    List<RaycastResult> results = new List<RaycastResult>();
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& clicker ==false)
        { 
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the game object
            m_PointerEventData.position = Input.mousePosition;
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            if (results[0].gameObject.tag == "Scroll Rect")
            {
                notScrollRect = false;
                results = new List<RaycastResult>();
            }
            else { notScrollRect = true;
            
            }
            Debug.Log(results[0]);

            if (results.Count > 0 && notScrollRect == true)
            {
                //StartingObjectPosition = results[0].gameObject.transform.position;
                results[0].gameObject.GetComponent<TweenCards>().enabled = true;
                results[0].gameObject.transform.parent = parent.transform;
                Debug.Log("Hit " + results[0].gameObject.name);
                Debug.Log(StartingObjectPosition);
                clicker = true;
            }
        }
        else if (Input.GetMouseButtonDown(0) && clicker == true)
        {
            results[0].gameObject.GetComponent<TweenCards>().enabled = false;
            results[0].gameObject.transform.parent = content.transform;
            //results[0].gameObject.transform.position = StartingObjectPosition;
            clicker = false;
            results = new List<RaycastResult>();
        }
        
    }

}
