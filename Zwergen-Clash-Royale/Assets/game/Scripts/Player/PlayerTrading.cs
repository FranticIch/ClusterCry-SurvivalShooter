using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrading : MonoBehaviour {

    //Inventory inventory;
    public bool traderInRange = false;
    GameObject trader;
    GameObject player;

    public GameObject tradingMenu;

	// Use this for initialization
	void Start () {
        //inventory = GetComponentInChildren<Inventory>();
        //player = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if(traderInRange && Input.GetKeyDown(KeyCode.T))
        {
            StartTraiding();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trader"))
        {
            traderInRange = true;
            trader = other.gameObject;
            Debug.Log(trader.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            traderInRange = false;
            trader = null;
        }
            
    }

    void StartTraiding()
    {
        Time.timeScale = 0;
        tradingMenu.GetComponent<Canvas>().enabled = true;
        Debug.Log("Start Trading");
        trader.GetComponent<TraderScript>().Trading();
    }

    public void EndTrading()
    {
        Time.timeScale = 1;
        tradingMenu.GetComponent<Canvas>().enabled = false;
    }


}
