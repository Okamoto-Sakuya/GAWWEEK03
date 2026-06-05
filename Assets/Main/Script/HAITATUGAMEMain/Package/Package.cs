using UnityEngine;

public class Package : MonoBehaviour
{
    [Header("‰×•¨”Ô†")]
    public int packageIndex;

    private GameObject hintEffect;

    // Œ³ˆÊ’u
    [HideInInspector]
    public Vector3 startPosition;

    // Œ³‰ñ“]
    [HideInInspector]
    public Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;

        startRotation = transform.rotation;

        // qObjectæ“¾
        Transform effect =
            transform.Find("HintEffect");

        if (effect != null)
        {
            hintEffect = effect.gameObject;

            hintEffect.SetActive(false);
        }
        else
        {
            Debug.LogError(
                gameObject.name +
                " ‚É HintEffect ‚ª–³‚¢"
            );
        }
    }

    // ƒqƒ“ƒgON
    public void EnableHighlight()
    {
        if (hintEffect != null)
        {
            Debug.Log(gameObject.name + " Œõ‚é");

            hintEffect.SetActive(true);
        }
    }

    // ƒqƒ“ƒgOFF
    public void DisableHighlight()
    {
        if (hintEffect != null)
        {
            hintEffect.SetActive(false);
        }
    }
}