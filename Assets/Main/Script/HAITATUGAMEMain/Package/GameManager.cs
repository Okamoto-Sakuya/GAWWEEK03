using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("スコアUI")]
    public TextMeshProUGUI scoreText;

    // スコア
    private int score;

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
        UpdateScoreText();

        SpawnSet();
    }

    // ===== 生成 =====
    public void SpawnSet()
    {
        // 0,1,2
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

        // 荷物生成
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

        // 配達先
        currentIndex =
            Random.Range(0, deliveryPrefabs.Length);

        currentDelivery =
            Instantiate(
                deliveryPrefabs[currentIndex],
                deliverySpawnPoint.position,
                Quaternion.identity
            );
        // ヒント表示
        UpdatePackageHighlight();
    }

    // ===== 配達成功 =====
    public void DeliveryComplete()
    {
        // スコア加算
        score++;

        UpdateScoreText();

        // 荷物削除
        foreach (GameObject package in currentPackages)
        {
            Destroy(package);
        }

        currentPackages.Clear();

        // 配達先削除
        Destroy(currentDelivery);

        // 次生成
        SpawnSet();
    }

    // UI更新
    void UpdateScoreText()
    {
        scoreText.text =
            "Score : " + score;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
    void UpdatePackageHighlight()
    {
        foreach (GameObject obj in currentPackages)
        {
            Package package =
                obj.GetComponent<Package>();

            if (package.packageIndex == currentIndex)
            {
                package.EnableHighlight();
            }
            else
            {
                package.DisableHighlight();
            }
        }
    }
}