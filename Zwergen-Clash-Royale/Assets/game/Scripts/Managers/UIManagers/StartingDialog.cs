using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : MonoBehaviour {
    public Canvas _startingMenuCanvas;
    private void Start()
    {
        Time.timeScale = 0;
    }
        public void CloseStartingMenu()
    {
        Time.timeScale = 1;
        _startingMenuCanvas.enabled = false;
        
    }
}
