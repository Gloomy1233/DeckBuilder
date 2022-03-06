using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDeck : MonoBehaviour
{
    public List<RawImage> Rawimages = new List<RawImage>();
    public List<RawImage> Deck = new List<RawImage>();
    public string name;
    public string rarity;
    public string link;
    public int hp;
    public string type;
    public float PosX, PosY;
    public List<bool> trues = new List<bool>();
    
    void Start()
    {
        for (int i = 0; i < 18; i++)
        {
                trues[i] = false;

        }
    }
    public void SaveGame()
    {
        for (int i = 0; i < 44; i++)
        {

            PlayerPrefs.SetString("Savedname["+i+"]", Rawimages[i].GetComponent<CardData>().name);
            PlayerPrefs.SetString("Savedrarity[" + i + "]", Rawimages[i].GetComponent<CardData>().rarity);
            PlayerPrefs.SetString("Savedlink[" + i + "]", Rawimages[i].GetComponent<CardData>().link);
            PlayerPrefs.SetInt("Savedhp[" + i + "]", Rawimages[i].GetComponent<CardData>().hp);
            //PlayerPrefs.SetString("Savedtype", type);
            PlayerPrefs.SetFloat("SavedPosX[" + i + "]", Rawimages[i].gameObject.transform.position.x);
            PlayerPrefs.SetFloat("SavedPosY[" + i + "]", Rawimages[i].gameObject.transform.position.y);
            PlayerPrefs.SetFloat("SavedPosZ[" + i + "]", Rawimages[i].gameObject.transform.position.z);
            PlayerPrefs.Save();
            
        }
        for (int i = 0; i < 18; i++)
        {
            if (Deck[i].transform.childCount > 0)
            {
                PlayerPrefs.SetFloat("SavedPosXDeck[" + i + "]", Rawimages[i].gameObject.transform.position.x);
                PlayerPrefs.SetFloat("SavedPosYDeck[" + i + "]", Rawimages[i].gameObject.transform.position.y);
                PlayerPrefs.SetFloat("SavedPosZDeck[" + i + "]", Rawimages[i].gameObject.transform.position.z);
                trues[i] = true;
                Debug.Log(PlayerPrefs.GetFloat("SavedPosXDeck[" + i + "]"));

            }
        }
    }

    public void LoadGame()
    {
        for (int i = 0; i < 44; i++)
        {

            Rawimages[i].GetComponent<CardData>().name = PlayerPrefs.GetString("Savedname[" + i + "]");
            Rawimages[i].GetComponent<CardData>().rarity = PlayerPrefs.GetString("Savedrarity[" + i + "]");
            Rawimages[i].GetComponent<CardData>().link = PlayerPrefs.GetString("Savedlink[" + i + "]");
            Rawimages[i].GetComponent<CardData>().hp = PlayerPrefs.GetInt("Savedhp[" + i + "]");
            //PlayerPrefs.SetString("Savedtype", type);
            if (Rawimages[i].gameObject.transform.position.x != PlayerPrefs.GetFloat("SavedPosX[" + i + "]") && Rawimages[i].gameObject.transform.position.y != PlayerPrefs.GetFloat("SavedPosY[" + i + "]"))
            {
                for (int j = 0; j < 18; j++)
                {
                    //Debug.Log(PlayerPrefs.GetFloat("SavedPosX[" + i + "]"));
                    Debug.Log(PlayerPrefs.GetFloat("SavedPosXDeck[" + j + "]"));
                    if (PlayerPrefs.GetFloat("SavedPosX[" + i + "]") == PlayerPrefs.GetFloat("SavedPosXDeck[" + j + "]"))
                    {
                        Rawimages[i].gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2.2f, gameObject.transform.localScale.y / 2.2f, gameObject.transform.localScale.z);
                        Rawimages[i].gameObject.transform.parent = Deck[j].transform;
                        Rawimages[i].gameObject.transform.localPosition = new Vector3(0, 0, 0);
                       // Rawimages[i].gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("SavedPosXDeck[" + j + "]"), PlayerPrefs.GetFloat("SavedPosYDeck[" + j + "]"), PlayerPrefs.GetFloat("SavedPosZDeck[" + j + "]"));
                        

                    }
                }
            }
            else
            {
                PlayerPrefs.SetFloat("SavedPosX[" + i + "]", Rawimages[i].gameObject.transform.position.x);
                PlayerPrefs.SetFloat("SavedPosY[" + i + "]", Rawimages[i].gameObject.transform.position.y);
                PlayerPrefs.SetFloat("SavedPosZ[" + i + "]", Rawimages[i].gameObject.transform.position.z);
            }
           // PlayerPrefs.Save();
            Debug.Log("Game data loadded");
        }
    }
}
