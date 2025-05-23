using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Path : LiemMonoBehaviour
{
    [SerializeField] protected List<Point> points = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point point = child.GetComponent<Point>();
            point.LoadNextPoint();
            this.points.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadPoints", gameObject);
    }
    public virtual Point GetPoint(int index)
    {
        return this.points[index];
    }

}
