using System.Collections;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    public float spawnInterval = 2f;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFire();
            timer = 0;
        }
    }

    void SpawnFire()
    {
        BoxCollider box = GetComponent<BoxCollider>();

     
        int side = Random.Range(0, 5); 
        Vector3 point = Vector3.zero;

        switch (side)
        {
            case 0: // Top
                point = new Vector3(
                    Random.Range(-box.size.x / 2, box.size.x / 2),
                    box.size.y / 2,
                    Random.Range(-box.size.z / 2, box.size.z / 2));
                break;
            case 1: // Front
                point = new Vector3(
                    Random.Range(-box.size.x / 2, box.size.x / 2),
                    Random.Range(-box.size.y / 2, box.size.y / 2),
                    box.size.z / 2);
                break;
            case 2: // Back
                point = new Vector3(
                    Random.Range(-box.size.x / 2, box.size.x / 2),
                    Random.Range(-box.size.y / 2, box.size.y / 2),
                    -box.size.z / 2);
                break;
            case 3: // Left
                point = new Vector3(
                    -box.size.x / 2,
                    Random.Range(-box.size.y / 2, box.size.y / 2),
                    Random.Range(-box.size.z / 2, box.size.z / 2));
                break;
            case 4: // Right
                point = new Vector3(
                    box.size.x / 2,
                    Random.Range(-box.size.y / 2, box.size.y / 2),
                    Random.Range(-box.size.z / 2, box.size.z / 2));
                break;
        }

        point = transform.TransformPoint(point + box.center);
        Instantiate(firePrefab, point, Quaternion.identity);
    }
}



