using BGS.Util;
using UnityEngine;

namespace BGS.Gameplay
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimations : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Animator _animator;
        private readonly AnimatorUtil _animatorUtil = new();

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            _animatorUtil.SetWalkAnimatorState(_animator,_movement);
        }

       
    }
}
