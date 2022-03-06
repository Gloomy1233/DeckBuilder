using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckChooser : MonoBehaviour
{
    public GameObject canvas1, canvas2, canvas3;
    
    public void deck1()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
    }
    public void deck2()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        canvas3.SetActive(false);
    }
    public void deck3()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
    }
}
