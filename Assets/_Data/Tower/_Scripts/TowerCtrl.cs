using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : LiemMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    protected string bulletName = "Bullet";
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;
    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadFirePoints();
        this.LoadBulletPrefabs();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.LogWarning(transform.name + ": LoadTowerTargeting", gameObject);
    }
    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectOfType<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }
    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetByName(this.bulletName);
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }
    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.LogWarning(transform.name + ": LoadBulletPrefabs", gameObject);
        this.LoadBullet();

    }
    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning(transform.name + ": LoadFirePoints", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        this.bullet.gameObject.SetActive(false);
    }
}
