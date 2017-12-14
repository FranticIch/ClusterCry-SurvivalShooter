using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class Inventory : MonoBehaviour
{
    private int _coins = 0;
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

    public void AddCoins(int coins) {
        _coins += coins;
    }

    public void AddPotionsWithMoney()
    {
        if (Coins >= 10)
        {
            _potions++;
            _coins -= 10;
        }

    }

    public void AddPotions(int potions) {
        _potions += potions;
    }

    public void AddAmmunitionWithMoney()
    {
        if (Coins >= 1)
        {
            FindObjectOfType<PlayerShooting>().AddAmmunition();
            Coins--;
        }
    }

    public void AddAmmunition(int bullets) {

        PlayerShooting ps = FindObjectOfType<PlayerShooting>();

        for (int i=0; i<bullets; i++) {  
            ps.AddAmmunition();
        }
    }

    public void AddGrenadesWithMoney()
    {
        if (Coins >= 5)
        {
            FindObjectOfType<Grenade>().AddGrenade();
            Coins -= 5;
        }
    }

    public void AddGrenades(int grenades) {

        Grenade g = FindObjectOfType<Grenade>();
        for(int i=0; i<grenades; i++) {
            g.AddGrenade();
        }
    }
}
