using UnityEngine;

public class PlayerDelivery : MonoBehaviour
{
    [Header("持つ位置")]
    public Transform holdPoint;

    private Package currentPackage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R押した");

            DropPackage();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // ===== 荷物取得 =====
        if (other.CompareTag("Package"))
        {
            // 既に持ってる
            if (currentPackage != null)
                return;

            currentPackage =
                other.GetComponent<Package>();

            // 持つ
            currentPackage.transform.SetParent(holdPoint);

            currentPackage.transform.localPosition =
                Vector3.zero;

            currentPackage.transform.localRotation =
                Quaternion.identity;

            // Rigidbody停止
            Rigidbody rb =
                currentPackage.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Collider OFF
            Collider col =
                currentPackage.GetComponent<Collider>();

            if (col != null)
            {
                col.enabled = false;
            }

            Debug.Log("荷物取得");
        }

        // ===== 配達 =====
        if (other.CompareTag("DeliveryPoint"))
        {
            if (currentPackage == null)
                return;

            DeliveryPoint point =
                other.GetComponent<DeliveryPoint>();

            // 色一致
            if (currentPackage.packageIndex ==
                point.pointIndex)
            {
                Debug.Log("配達成功");

                Destroy(currentPackage.gameObject);

                currentPackage = null;

                GameManager.instance.DeliveryComplete();
            }
            else
            {
                Debug.Log("違う色");
            }
        }
    }

    // ===== 荷物を落とす =====
    void DropPackage()
    {
        // 荷物持ってない
        if (currentPackage == null)
        {
            Debug.Log("荷物なし");

            return;
        }

        Debug.Log("荷物戻す");

        // 親解除
        currentPackage.transform.SetParent(null);

        // 元位置へ戻す
        currentPackage.transform.position =
            currentPackage.startPosition;

        // 元回転
        currentPackage.transform.rotation =
            currentPackage.startRotation;

        // Rigidbody
        Rigidbody rb =
            currentPackage.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;

            rb.linearVelocity = Vector3.zero;

            rb.angularVelocity = Vector3.zero;
        }

        // Collider ON
        Collider col =
            currentPackage.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = true;
        }

        currentPackage = null;
    }
}