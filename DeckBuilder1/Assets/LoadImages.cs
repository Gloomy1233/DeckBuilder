using System.Collections;
using System;

using System.Collections.Generic;
using System.Linq;

using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
    public List<RawImage> Rawimages = new List<RawImage>();
    public List<RawImage> RawimagesTemp = new List<RawImage>();

    void Awake()

    {
        var textFile = Resources.Load<TextAsset>("CardList");
        string text = textFile.ToString();

        //string text = File.ReadAllText(fileName);
        Debug.Log(text);

        for(int i = 0; i < 44; i++) 
        {
            int startname = text.IndexOf(@"name_start") + 10;
            string srcname = text.Substring(startname, text.IndexOf("name_end", startname) - startname);
            RawimagesTemp[i].GetComponent<CardData>().name = srcname;
            Rawimages[i].GetComponent<CardData>().name = srcname ;
            Debug.Log(srcname);



            int start = text.IndexOf(@"image_start") + 11;
            string src = text.Substring(start, text.IndexOf("image_end", start) - start);
            Rawimages[i].GetComponent<CardData>().link = src;
            RawimagesTemp[i].GetComponent<CardData>().link = src;
            Debug.Log(src);
            StartCoroutine(DownloadImage(src, i));



            int startrarity= text.IndexOf(@"rarity_start") + 12;
            string srcrarity= text.Substring(startrarity, text.IndexOf("rarity_end", startrarity) - startrarity);
            Rawimages[i].GetComponent<CardData>().rarity = srcrarity;
            RawimagesTemp[i].GetComponent<CardData>().rarity = srcrarity;
            Debug.Log(srcrarity);




            int starthp = text.IndexOf(@"hp_start") + 8;
            string srchp = text.Substring(starthp, text.IndexOf("hp_start", starthp) - starthp);
            Rawimages[i].GetComponent<CardData>().hp = Convert.ToInt32(srchp);
            RawimagesTemp[i].GetComponent<CardData>().hp = Convert.ToInt32(srchp);
            Debug.Log(srchp);



            int starttype = text.IndexOf(@"type_start") + 10;
            string srctype = text.Substring(starttype, text.IndexOf("type_start", starttype) - starttype);
            Rawimages[i].GetComponent<CardData>().type = srctype ;
            //DescendingImages[i].GetComponent<CardData>().link = srctype;
            Debug.Log(srctype);

            
            int ender = text.IndexOf("++++>>")+1;
            Debug.Log(ender);
            

            text = text.Substring(ender);
            
        }
         //StartCoroutine(DownloadImage("https://images.pokemontcg.io/xy6/57.png", 1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
