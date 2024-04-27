using BGS.SO;
using BGS.Util;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace BGS.Gameplay
{
    public class WearablesAnim : MonoBehaviour
    {
        public  WearableSO animationSheet;
        
        private Animator _animator;
        private readonly AnimatorUtil _animatorUtil = new();
        private PlayerMovement _movement;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponentInParent<PlayerMovement>();
        }

        private void Update()
        {
            _animatorUtil.SetWalkAnimatorState(_animator, _movement);
        }

        public void SwapSpritesInAnimations()
        {
            SwapSpritesInAnimations(animationSheet);
        }
        
        public void SwapSpritesInAnimations(WearableSO so)
        {
            if (_animator == null)
            {
                Debug.LogError("Animator not assigned!");
                return;
            }

            animationSheet = so;
            var controller = _animator.runtimeAnimatorController;
            var clips = controller!.animationClips;

            for (var i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                SwapSpritesInAnimation(clip, animationSheet.spriteAnimationsList[i]);
            }
        }

        private void SwapSpritesInAnimation(AnimationClip animationClip, SpriteAnimations sprites)
        {
            if (animationClip == null)
            {
                Debug.LogError("AnimationClip is null!");
                return;
            }

            var clipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);

            var curveBindings = AnimationUtility.GetObjectReferenceCurveBindings(animationClip);

            foreach (var binding in curveBindings)
            {
                if (binding.propertyName != "m_Sprite") continue;

                var keyframes = AnimationUtility.GetObjectReferenceCurve(animationClip, binding);

                for (var i = 0; i < keyframes.Length; i++)
                {
                    var spriteIndex = Mathf.Clamp(i, 0, sprites.animations.Count - 1);
                    keyframes[i].value = sprites.animations[spriteIndex];
                }

                AnimationUtility.SetObjectReferenceCurve(animationClip, binding, keyframes);
            }

            AnimationUtility.SetAnimationClipSettings(animationClip, clipSettings);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(WearablesAnim))]
    public class ClothesAnimEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            WearablesAnim wearablesAnim = (WearablesAnim)target;

            if (GUILayout.Button("Swap Sprites in Animations"))
            {
                wearablesAnim.SwapSpritesInAnimations();
            }
        }
    }
#endif
}