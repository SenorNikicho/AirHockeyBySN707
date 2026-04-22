using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody player;

    [SerializeField] private float _force = 5f;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    public void MoveUp()
    {
        player.AddForce(Vector3.forward * _force, ForceMode.Impulse);
    }

    public void MoveDown()
    {
        player.AddForce(Vector3.back * _force, ForceMode.Impulse);
    }

    public void MoveLeft()
    {
        player.AddForce(Vector3.left * _force, ForceMode.Impulse);
    }

    public void MoveRight()
    {
        player.AddForce(Vector3.right * _force, ForceMode.Impulse);
    }
}
