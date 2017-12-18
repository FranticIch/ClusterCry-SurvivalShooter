using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : MonoBehaviour {
    public Canvas _startingMenuCanvas;
    private void Start()
    {
    }
        public void CloseStartingMenu()
    {
        _startingMenuCanvas.enabled = false;
        
    }
}
