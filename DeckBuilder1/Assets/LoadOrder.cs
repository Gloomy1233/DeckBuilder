using System.Collections;
using System;

using System.Collections.Generic;
using System.Linq;

using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadOrder : MonoBehaviour
{
    public List<RawImage> StartingImages = new List<RawImage>();
    public List<RawImage> DescendingImages = new List<RawImage>();

    void Awake()
    {
        var textfile = Resources.Load<TextAsset>(@"CardList.txt");
        string fileName = textfile.ToString();

        string text = File.ReadAllText(fileName);
        Debug.Log(text);

        for (int i = 0; i < 44; i++)
        {
            int startname = text.IndexOf(@"name_start") + 10;
            string srcname = text.Substring(startname, text.IndexOf("name_end", startname) - startname);
            DescendingImages[i].GetComponent<CardData>().name = srcname;
            StartingImages[i].GetComponent<CardData>().name = srcname;
            Debug.Log(srcname);



            int start = text.IndexOf(@"image_start") + 11;
            string src = text.Substring(start, text.IndexOf("image_end", start) - start);
            StartingImages[i].GetComponent<CardData>().link = src;
            DescendingImages[i].GetComponent<CardData>().link = src;
            Debug.Log(src);
           



            int startrarity = text.IndexOf(@"rarity_start") + 12;
            string srcrarity = text.Substring(startrarity, text.IndexOf("rarity_end", startrarity) - startrarity);
            StartingImages[i].GetComponent<CardData>().rarity = srcrarity;
            DescendingImages[i].GetComponent<CardData>().rarity = srcrarity;
            Debug.Log(srcrarity);




            int starthp = text.IndexOf(@"hp_start") + 8;
            string srchp = text.Substring(starthp, text.IndexOf("hp_start", starthp) - starthp);
            StartingImages[i].GetComponent<CardData>().hp = Convert.ToInt32(srchp);
            DescendingImages[i].GetComponent<CardData>().hp = Convert.ToInt32(srchp);
            Debug.Log(srchp);



            int starttype = text.IndexOf(@"type_start") + 10;
            string srctype = text.Substring(starttype, text.IndexOf("type_start", starttype) - starttype);
            StartingImages[i].GetComponent<CardData>().type = srctype;
            //DescendingImages[i].GetComponent<CardData>().link = srctype;
            Debug.Log(srctype);


            int ender = text.IndexOf("++++>>") + 1;
            Debug.Log(ender);


            text = text.Substring(ender);

        }
        //StartCoroutine(DownloadImage("https://images.pokemontcg.io/xy6/57.png", 1));

    }

    // Update is called once per frame
    void Update()
    {

    }


}
