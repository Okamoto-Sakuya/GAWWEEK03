using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Vector2 moveInput;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E押された（直接取得）");
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // ★追加（Eキーで呼ばれる）
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("撃った");
            Shoot(); // ←これ追加
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}