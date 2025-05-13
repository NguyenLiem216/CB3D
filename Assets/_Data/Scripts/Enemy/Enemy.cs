using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHP = 100;
    int maxHP = 100;
    float weight = 1f;
    float minWeight = 1f;
    float maxWeight = 10f;
    bool isDead = false;
    bool isBoss = true;

    void Reset()
    {
        this.InitData();
    }

    void OnEnable()
    {
        this.InitData();    
    }

    public abstract string GetName();

    public virtual string GetObjName()
    {
        return transform.name; // or use gameObject.name 
    }

    protected virtual void InitData()
    {
        this.weight = this.GetRandomWeight();
    }

    protected virtual float GetRandomWeight()
    {
        return Random.Range(this.minWeight, this.maxWeight);
    }



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


    public virtual float GetWeight()
    {
        return this.weight;
    }

    public virtual float GetMaxWeight()
    {
        return this.maxWeight;
    }
    public virtual float GetMinWeight()
    {
        return this.minWeight;
    }

    public virtual bool IsBoss()
    {
        return this.isBoss;
    }

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }
}
