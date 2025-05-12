using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHP = 100;
    int maxHP = 100;
    float weight = 2.5f;
    bool isDead = false;
    bool isBoss = true;

    

    public abstract string GetName();

    

    public virtual bool IsDead()
    {
        if (this.currentHP > 0) this.isDead = false;
        else this.isDead = true;


        return this.isDead;
    }

    public virtual int GetCurrentHP()
    {
        return this.currentHP;
    }

    public virtual int GetMaxHP()
    {
        return this.maxHP;
    }
    public virtual void SetHP(int newHP)
    {
        this.currentHP = newHP;
    }


    float GetWeight()
    {
        return this.weight;
    }

    bool IsBoss()
    {
        return this.isBoss;
    }

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }
}
