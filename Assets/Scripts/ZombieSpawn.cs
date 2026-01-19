using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnTime = 2.5f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[spawnIndex].position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPos, out hit, 1f, NavMesh.AllAreas))
        {
            GameObject zombie = Instantiate(zombiePrefab, hit.position, spawnPoints[spawnIndex].rotation);

            NavMeshAgent agent = zombie.GetComponent<NavMeshAgent>();
            if (agent != null)
                agent.enabled = true;
        }
    }
}
