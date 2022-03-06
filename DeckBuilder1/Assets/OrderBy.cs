using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class OrderBy : MonoBehaviour
{
  
    public List<RawImage> Rawimages = new List<RawImage>();
    public List<RawImage> RawimagesTemp = new List<RawImage>();
    public List<RawImage> StartingImages = new List<RawImage>();
    public List<RawImage> DescendingImages = new List<RawImage>();
    public bool hpOrder=true;
    public Sprite Empty, Full;
    public Texture2D cursorTex;
    int i = 43;
    int j = 0;
    void Start()
    {
        Cursor.SetCursor(cursorTex,Vector2.zero,CursorMode.Auto);
        gameObject.GetComponent<Image>().sprite = Empty;
        RawimagesTemp = RawimagesTemp.OrderBy(RawimagesTemp => RawimagesTemp.GetComponent<CardData>().hp).ToList();
        DescendingImages = DescendingImages.OrderBy(DescendingImages => DescendingImages.GetComponent<CardData>().hp).ToList();
    }
    
    public void SortRarity()
    {
        gameObject.transform.DOPunchScale(new Vector3((float)(gameObject.transform.localScale.x * 1.01), (float)(gameObject.transform.localScale.y * 1.01), (float)(gameObject.transform.localScale.z)), 1,2,1);
        if (hpOrder)
        {
            foreach (RawImage rawImage in RawimagesTemp)
            {

                Rawimages[i].GetComponent<CardData>().name = rawImage.GetComponent<CardData>().name;
                Rawimages[i].GetComponent<CardData>().link = rawImage.GetComponent<CardData>().link;
                Rawimages[i].GetComponent<CardData>().rarity = rawImage.GetComponent<CardData>().rarity;
                Rawimages[i].GetComponent<CardData>().hp = rawImage.GetComponent<CardData>().hp;
                Rawimages[i].GetComponent<CardData>().type = rawImage.GetComponent<CardData>().type;

                i = i - 1;
                Debug.Log(rawImage.GetComponent<CardData>().link);

            }
            for (int i = 0; i < 44; i++)
            {
                Debug.Log(Rawimages[i].GetComponent<CardData>().link);
                StartCoroutine(DownloadImage(Rawimages[i].GetComponent<CardData>().link, i));
            }
             i = 43;
            gameObject.GetComponent<Image>().sprite = Empty;
            hpOrder = false;
        }
        else if (!hpOrder)
        {
            foreach (RawImage rawImage in DescendingImages)
            {

                Rawimages[j].GetComponent<CardData>().name = rawImage.GetComponent<CardData>().name;
                Rawimages[j].GetComponent<CardData>().link = rawImage.GetComponent<CardData>().link;
                Rawimages[j].GetComponent<CardData>().rarity = rawImage.GetComponent<CardData>().rarity;
                Rawimages[j].GetComponent<CardData>().hp = rawImage.GetComponent<CardData>().hp;
                Rawimages[j].GetComponent<CardData>().type = rawImage.GetComponent<CardData>().type;

                j = j + 1;
                Debug.Log(rawImage.GetComponent<CardData>().link);

            }
            for (int i = 43; i >= 0; i--)
            {
                Debug.Log(Rawimages[i].GetComponent<CardData>().link);
                StartCoroutine(DownloadImage(Rawimages[i].GetComponent<CardData>().link, i));
            }
            j = 0;
            hpOrder = true;
            gameObject.GetComponent<Image>().sprite = Full;
        }

    }

    IEnumerator DownloadImage(string MediaUrl, int i)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log("lyteokerglergolrgeolergoergol");
        else
            Rawimages[i].texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}



