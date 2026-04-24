using UnityEngine;
using UnityEngine.InputSystem;

public class MovementArrows : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force = 5f;
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Debug.Log($"Стрелки: {input}"); // ← добавить эту строку
        moveInput = input;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        if (move != Vector3.zero)
        {
            Debug.Log($"FixedUpdate: применяю силу {move.normalized * force}");
            rb.AddForce(move.normalized * force, ForceMode.Force);
        }
    }
}