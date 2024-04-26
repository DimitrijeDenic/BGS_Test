using BGS.Gameplay;
using UnityEngine;

namespace BGS.Util
{
    public class AnimatorUtil
    {
        private static readonly int Y = Animator.StringToHash("Y");
        private static readonly int X = Animator.StringToHash("X");

        public void SetWalkAnimatorState(Animator animator,PlayerMovement movement)
        {
            var input = movement.GetInput();
            animator.SetFloat(Y, input.y);
            animator.SetFloat(X, input.x);
        }
        
    }
}