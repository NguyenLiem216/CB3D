using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : LiemMonoBehaviour
{
    [SerializeField] protected Point nextPoint;
    public Point NextPoint => nextPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNextPoint();
    }

    public virtual void LoadNextPoint()
    {
        if (this.nextPoint != null) return;
        int nextIndex = transform.GetSiblingIndex() + 1;

        if (nextIndex < transform.parent.childCount)
        {
            Transform nextSibling = transform.parent.GetChild(nextIndex);
            this.nextPoint = nextSibling.GetComponent<Point>();
        }
        Debug.Log(transform.name + ": LoadNextPoint", gameObject);
    }
}
