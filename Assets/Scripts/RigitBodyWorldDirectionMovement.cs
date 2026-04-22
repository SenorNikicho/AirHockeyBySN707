using UnityEngine;

namespace Movement
{
    public class RigidbodyWorldDirectionalMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _force = 5f;
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody.AddForce(Vector3.forward * _force, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.AddForce(Vector3.left * _force, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody.AddForce(Vector3.back * _force, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.AddForce(Vector3.right * _force, ForceMode.Impulse);
            }
        }
    }
}
