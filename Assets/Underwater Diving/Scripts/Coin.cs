using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public GameObject playerItem;
    public Color tmp;



    void OnTriggerEnter2D(Collider2D col)
    {

        //CoinPanel.coinAmount += 1;
        Destroy(gameObject);

    }
}
