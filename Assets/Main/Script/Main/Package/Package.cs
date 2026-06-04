using UnityEngine;

public class Package : MonoBehaviour
{
    public int packageIndex;

    [HideInInspector]
    public Vector3 startPosition;

    [HideInInspector]
    public Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;

        startRotation = transform.rotation;
    }
}