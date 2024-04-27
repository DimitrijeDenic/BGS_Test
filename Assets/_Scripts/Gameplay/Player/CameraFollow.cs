using UnityEngine;

namespace BGS.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // The target object to follow
        public float smoothSpeed = 5f; // The speed at which the camera follows the target
        public Vector3 offset; // The offset of the camera from the target

        private Vector3 desiredPosition; // The desired position of the camera

        void FixedUpdate()
        {
            if (target == null)
            {
                Debug.LogWarning("Camera target not set!");
                return;
            }

            desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }

        // Optionally, you can add Gizmos to visualize the offset
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + offset, 0.1f);
        }
    }
}