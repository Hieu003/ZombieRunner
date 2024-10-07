using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
    public GameObject bulletPickups;
    public GameObject shellPickups;
    public GameObject batteryPickups;

    public int xPos;
    public int zPos;
    public int BulletCount;
    public int ShellCount;
    public int BatteryCount;

    private List<Vector3> occupiedPositions = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(SpawnBulletPickUps());
        StartCoroutine(SpawnShellPickUps());
        StartCoroutine(SpawnBatteryPickUps());
    }

    private IEnumerator SpawnBulletPickUps()
    {
        while (BulletCount < 20)
        {
            Vector3 spawnPosition = GetUniquePosition();
            Instantiate(bulletPickups, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1);
            BulletCount += 1;
        }
    }

    private IEnumerator SpawnShellPickUps()
    {
        while (ShellCount < 20)
        {
            Vector3 spawnPosition = GetUniquePosition();
            Instantiate(shellPickups, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1);
            ShellCount += 1;
        }
    }

    private IEnumerator SpawnBatteryPickUps()
    {
        while (BatteryCount < 20)
        {
            Vector3 spawnPosition = GetUniquePosition();
            Instantiate(batteryPickups, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1);
            BatteryCount += 1;
        }
    }

    private Vector3 GetUniquePosition()
    {
        Vector3 position;
        bool positionFound = false;

        do
        {
            position = new Vector3(Random.Range(20, 120), 55, Random.Range(-50, 80));
            positionFound = !occupiedPositions.Contains(position);
        } while (!positionFound);

        occupiedPositions.Add(position);
        return position;
    }
}

