using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    void FixedUpdate()
    {
        //this.TestClass();  
        this.TestIsDead();
    }

    void TestIsDead()
    {
        
    }

    void TestClass()
    {
        Zombie zombie = new Zombie();
        Wolf wolf = new Wolf();
        Eagle eagle = new Eagle();
        Ghost ghost = new Ghost();

        zombie.Moving();
        wolf.Moving();
        eagle.Moving();
        ghost.Moving();
    }
}
