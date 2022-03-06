
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class DragAndleave : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject Content;
    private Vector2 lastMousePosition;
    private Vector2 StartingObjectPosition;
    public bool EndClick,cooldown,cooldownend;
    public RawImage[] deckimages;
    int UILayer;
    public Texture2D PlaceholderTex;
    /// <summary>
    /// This method will be called on the start of the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    /// 

    public void OnBeginDrag(PointerEventData eventData)
    {
      

            if (EndClick == true)
                    {
                        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2.2f, gameObject.transform.localScale.y * 2.2f, gameObject.transform.localScale.z);
                    }
                    EndClick = false;
                    lastMousePosition = eventData.position;
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x/3, gameObject.transform.localScale.y/3, gameObject.transform.localScale.z);
                    StartingObjectPosition = gameObject.transform.position;

      
    }

    /// <summary>
    /// This method will be called during the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnDrag(PointerEventData eventData)
    {
       

                Vector2 currentMousePosition = eventData.position;
                Vector2 diff = currentMousePosition - lastMousePosition;
                RectTransform rect = GetComponent<RectTransform>();

                Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
                Vector3 oldPos = rect.position;
                rect.position = newPosition;
        
                lastMousePosition = currentMousePosition;

    

    }

    /// <summary>
    /// This method will be called at the end of mouse drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        

            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 3, gameObject.transform.localScale.y * 3, gameObject.transform.localScale.z);
            gameObject.transform.position = StartingObjectPosition;
            EndClick = true;

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deckBuild")
        {
            collision.GetComponent<RawImage>().texture = gameObject.GetComponent<RawImage>().texture;
        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<RawImage>().texture = PlaceholderTex;
        if ( EndClick == true)
        {
            
                gameObject.transform.position = collision.transform.position;
                gameObject.transform.parent = collision.transform;
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2.2f, gameObject.transform.localScale.y / 2.2f, gameObject.transform.localScale.z);
            gameObject.transform.DOShakePosition(1,7);
             EndClick = false;
        }
    }

    public void Update()
    {
        for (int i = 0; i < 18; i++)
        {
            if (deckimages[i].transform.childCount > 1)
            {
                deckimages[i].transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                deckimages[i].transform.GetChild(0).transform.parent = Content.transform;

            }
        }

        if (gameObject.transform.localScale.x > 1.1f && gameObject.transform.localScale.y > 1.1f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void ResetCooldown()
    {
        cooldown = false;

    }


}

 