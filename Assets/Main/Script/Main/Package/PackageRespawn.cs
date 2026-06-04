using UnityEngine;

public class PackageRespawn : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
}