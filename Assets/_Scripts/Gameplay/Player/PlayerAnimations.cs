using BGS.Util;
using UnityEngine;

namespace BGS.Gameplay
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimations : MonoBehaviour
    {
        private PlayerMovement _movement;
        [SerializeField] private Animator animator;
        private readonly AnimatorUtil _animatorUtil = new();

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _animatorUtil.SetWalkAnimatorState(animator,_movement);
        }

       
    }
}
