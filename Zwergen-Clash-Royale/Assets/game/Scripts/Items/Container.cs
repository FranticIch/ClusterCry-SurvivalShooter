using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    private int _coins;
    private int _potions;
    private int _grenades;
    private int _ammuntion;
    private int _food;

    private int[] _items;

    private void Awake() {
        _coins = UnityEngine.Random.Range(0, 10);
        _potions = UnityEngine.Random.Range(0, 2);
        _grenades = UnityEngine.Random.Range(0, 1);
        _ammuntion = UnityEngine.Random.Range(0, 5);
        _food = UnityEngine.Random.Range(0, 3);
    }

    private void Start() {
        _items = new int[5] { _coins, _potions, _grenades, _ammuntion, _food };
    }

    public int[] Loot() {
        DeleteContainer();
        return _items;
    }

    private void DeleteContainer() {
        Destroy(gameObject);
    }
}
