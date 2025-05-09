using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHP = 100;
    int maxHP = 100;
    float weight = 2.5f;
    bool isDead = true;
    bool isBoss = true;

    EnemyHead head = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();


    protected abstract string GetName();

    int GetCurrentHP()
    {
        return this.currentHP;
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
