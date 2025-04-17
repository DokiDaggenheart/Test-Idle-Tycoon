using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public class MovementView : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;

        public void Move(Vector3 direction, float speed)
        {
            transform.position += direction * speed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}