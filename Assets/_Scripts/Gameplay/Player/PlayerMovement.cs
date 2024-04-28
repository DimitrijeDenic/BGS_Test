using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        private Vector2 _input;
        private Rigidbody2D _rigidbody2D;
        public AudioSource stepSource;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            GameManager.OnSceneChanged += SetStepSound;
        }

        private void OnDisable()
        {
            GameManager.OnSceneChanged -= SetStepSound;
        }

        private void SetStepSound()
        {
            stepSource.clip = GameManager.Instance.audioManager.SetStepSound();
        }
        private void Update()
        {
            _input = GetInput();
            
            if (_input != Vector2.zero && !stepSource.isPlaying)
            {
                stepSource.Play();
            }
            else if(_input == Vector2.zero)
            {
                stepSource.Stop();
            }
        }

        private void FixedUpdate()
        {
            if(GameManager.Instance.uiActive || _input == Vector2.zero) return;
            _rigidbody2D.MovePosition(_rigidbody2D.position + _input * (moveSpeed * Time.fixedDeltaTime));
        }

        public Vector2 GetInput()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}
