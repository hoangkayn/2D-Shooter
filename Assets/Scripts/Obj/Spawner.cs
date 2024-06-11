using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : BaseMono
{
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
 
    [SerializeField] protected int spawnedCount;
    public int SpawnedCount => spawnedCount;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();

    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform objPrefab = transform.Find("Prefabs").transform;
        foreach(Transform child in objPrefab)
        {
            this.prefabs.Add(child);
            this.HideAllPrefab();
        }
    }
    protected virtual void HideAllPrefab()
    {
        foreach(Transform child in prefabs) {
            child.gameObject.SetActive(false);
        }
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    public virtual Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot)
    {
        Transform prefab = CheckPrefab(namePrefab);
        if (prefab == null) Debug.LogError("prefab is null !");
        Transform newPrefab = GetPrefabToPool(prefab);
        newPrefab.SetPositionAndRotation(pos,rot);
        newPrefab.SetParent(holder);
        newPrefab.gameObject.SetActive(true);
        newPrefab.name = namePrefab;
        spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform CheckPrefab(string namePrefab)
    {
        foreach(Transform child in prefabs)
        {
            if (namePrefab == child.name) return child;
        }
        return null;
    }
    protected virtual Transform GetPrefabToPool(Transform prefab)
    {
        foreach(Transform child in poolObjs)
        {
            if (child == null) continue;
            if (child.name == prefab.name)
            {
                this.poolObjs.Remove(child);
                return child;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        return newPrefab;
    }
    public virtual Transform RandomPrefab()
    {
        int ran = Random.Range(0, prefabs.Count);
        return prefabs[ran];
    }
    public virtual void Despawn(Transform obj)
    {
        if (obj.gameObject.activeSelf == false) return;
        spawnedCount--;
        obj.gameObject.SetActive(false);
        this.poolObjs.Add(obj);
    }
    public virtual void Holder(Transform obj) {
        obj = this.holder;
    }

}
