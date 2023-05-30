using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject Player;
    Scrollbar Hbar;
    Scrollbar Sbar;
    // Start is called before the first frame update
    void Start()
    {
        Hbar = transform.GetChild(0).GetComponent<Scrollbar>();
        Sbar = transform.GetChild(1).GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player !=null)
        {
            Hbar.size = (float)Player.GetComponent<CharBehavior>().health / 200;
            Sbar.size = (float)Player.GetComponent<CharBehavior>().stm / 100;
        }
    }
    public void setPlayer(GameObject o)
    {
        Player = o;
    }
}
