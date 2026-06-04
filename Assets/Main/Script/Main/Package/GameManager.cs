using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("荷物Prefab")]
    public GameObject[] packagePrefabs;

    [Header("配達先Prefab")]
    public GameObject[] deliveryPrefabs;

    [Header("荷物スポナー")]
    public Transform[] packageSpawnPoints;

    [Header("配達先スポナー")]
    public Transform deliverySpawnPoint;

    private List<GameObject> currentPackages =
        new List<GameObject>();

    private GameObject currentDelivery;

    private int currentIndex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnSet();
    }

    // ===== 生成 =====
    public void SpawnSet()
    {
        // 0,1,2 を作る
        List<int> indexes =
            new List<int>() { 0, 1, 2 };

        // シャッフル
        for (int i = 0; i < indexes.Count; i++)
        {
            int random =
                Random.Range(i, indexes.Count);

            int temp = indexes[i];

            indexes[i] = indexes[random];

            indexes[random] = temp;
        }

        // ===== 荷物生成 =====

        for (int i = 0; i < packageSpawnPoints.Length; i++)
        {
            int colorIndex = indexes[i];

            GameObject package =
                Instantiate(
                    packagePrefabs[colorIndex],
                    packageSpawnPoints[i].position,
                    Quaternion.identity
                );

            currentPackages.Add(package);
        }

        // ===== 配達先 =====

        currentIndex =
            Random.Range(0, deliveryPrefabs.Length);

        currentDelivery =
            Instantiate(
                deliveryPrefabs[currentIndex],
                deliverySpawnPoint.position,
                Quaternion.identity
            );
    }

    // ===== 配達成功 =====
    public void DeliveryComplete()
    {
        foreach (GameObject package in currentPackages)
        {
            Destroy(package);
        }

        currentPackages.Clear();

        Destroy(currentDelivery);

        SpawnSet();
    }
}