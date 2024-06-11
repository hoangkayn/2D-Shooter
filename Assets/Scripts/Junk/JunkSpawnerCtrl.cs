using UnityEngine;

public class JunkSpawnerCtrl : BaseMono
{
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;
    [SerializeField] protected JunkSpanwer junkSpawner;
    public JunkSpanwer JunkSpawner => junkSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnPoint();
        this.LoadJunkSpawner();
    }
    protected virtual void LoadJunkSpawnPoint()
    {
        if (spawnPoint != null) return;
        spawnPoint = transform.GetComponentInChildren<SpawnPoint>();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (junkSpawner != null) return;
        junkSpawner = transform.GetComponent<JunkSpanwer>();
    }
}
