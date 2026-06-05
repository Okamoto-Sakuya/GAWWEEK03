using UnityEngine;

public class PackageReset : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
}