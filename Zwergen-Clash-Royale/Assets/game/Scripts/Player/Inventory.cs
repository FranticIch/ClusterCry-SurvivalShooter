using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class Inventory : MonoBehaviour
{
    private int _coins = 20;
    private int _potions;

    public int Coins
    {
        get
        {
            return _coins;
        }

        set
        {
            _coins = value;
        }
    }

    public int Potions
    {
        get
        {
            return _potions;
        }

        set
        {
            _potions = value;
        }
    }

    public bool TakePotion()
    {
        if (Potions > 0)
        {
            Potions--;
            return true;
        }

        return false;
    }

    public void AddPotion()
    {
        if (Coins >= 10)
        {
            _potions++;
            _coins -= 10;
        }

    }

    public void AddAmmunition()
    {
        if (Coins >= 1)
        {
            //Munition
            Coins--;
        }
    }

    public void AddGrenades()
    {
        if (Coins >= 5)
        {
            //Granaten weg
            Coins -= 5;
        }
    }
}
