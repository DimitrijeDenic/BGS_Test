using UnityEngine;

namespace BGS.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; 
        public float smoothSpeed = 5f;
        public Vector3 offset;

        private Vector3 _desiredPosition;

        private void FixedUpdate()
        {
            if (target == null)
            {
                Debug.LogWarning("Camera target not set!");
                return;
            }

            _desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
    }
}