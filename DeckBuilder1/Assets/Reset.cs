using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    List<RaycastResult> results = new List<RaycastResult>();
    public bool  notScrollRect;
    public GameObject picked;
    public void ResetScene()
    {
        SceneManager.LoadScene("DeckBuilder",LoadSceneMode.Single);
    }
    private void Update()
    {
        
            m_PointerEventData = new PointerEventData(m_EventSystem);

            m_PointerEventData.position = Input.mousePosition;

            m_Raycaster.Raycast(m_PointerEventData, results);
        if (results[0].gameObject != picked)
        {
            if (results[0].gameObject.tag == "Scroll Rect")
            {
                notScrollRect = false;
                results = new List<RaycastResult>();
            }
            else
            {
                notScrollRect = true;

            }

            if (results.Count > 0 && notScrollRect == true)
            {

                results[0].gameObject.transform.DOPunchScale(new Vector3(gameObject.transform.localScale.x*0.1f,gameObject.transform.localScale.y*0.1f,gameObject.transform.localScale.z),0.2f,1,0.001f);
                picked = results[0].gameObject;

            }
            //results = new List<RaycastResult>();
        }
        else
        {
            results = new List<RaycastResult>();
        }
            Debug.Log(results[0]);
        Debug.Log(picked);
    }

}
