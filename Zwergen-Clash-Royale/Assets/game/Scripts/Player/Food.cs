using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public float timeUntilHungry;

    private Inventory _inventory;
    private PlayerHealth _playerHealth;
    private float _timer;

	// Use this for initialization
	void Start () {
        _inventory = FindObjectOfType<Inventory>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;

        if (_timer > timeUntilHungry)
        {
            _timer = 0.0f;
            PlayerIsHungry();
        }
    }

    private void PlayerIsHungry()
    {
        if(_inventory.Food > 0)
        {
            _inventory.RemoveFood();
        }
        else
        {
            _playerHealth.TakeDamage(10, _playerHealth.gameObject.transform.position);
        }
    }
}
