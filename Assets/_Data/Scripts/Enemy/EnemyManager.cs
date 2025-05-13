using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> Enemies => enemies;

    Enemy smallestEnemy;
    Enemy biggestEnemy;

    private void Awake()
    {
        this.LoadEnemies();
    }

    void Start()
    {
        this.LoadSmallestEnemy();
        this.LoadBiggestEnemy();
    }

    protected virtual void LoadSmallestEnemy()
    {
        Enemy firstEnemy = this.enemies[0];
        float smallestWeight = firstEnemy.GetMaxWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight < smallestWeight)
            {
                smallestWeight = enemyWeight;
                this.smallestEnemy = enemy;
            }
            //Debug.Log(enemy.GetObjName() + ": " + enemy.GetWeight());
        }
    }
    protected virtual void LoadBiggestEnemy()
    {
        Enemy firstEnemy = this.enemies[0];
        float biggestWeight = firstEnemy.GetMinWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight > biggestWeight)
            {
                biggestWeight = enemyWeight;
                this.biggestEnemy = enemy;
            }
            Debug.Log(enemy.GetObjName() + ": " + enemy.GetWeight());
        }
    }

    protected virtual void LoadEnemies()
    {
        foreach (Transform childObj in transform)
        {
            //Debug.Log(childObj.name);
            Enemy enemy = childObj.GetComponent<Enemy>();
            if (enemy == null) continue;
            this.enemies.Add(enemy);

        }
    }
}
