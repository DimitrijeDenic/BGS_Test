using System;
using System.Collections.Generic;
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
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponentInParent<PlayerMovement>();
        }

        private void Update()
        {
            _animatorUtil.SetWalkAnimatorState(_animator, _movement);
        }
        public void SwapSpritesInAnimations(WearableSO so)
        {
            if (_animator == null)
            {
                Debug.LogError("Animator not assigned!");
                return;
            }

            
            var aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            for (var i = 0; i < aoc.animationClips.Length; i++)
            {
                var a = aoc.animationClips[i];
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, so.animationClips[i]));
            }

            aoc.ApplyOverrides(anims);
            _animator.runtimeAnimatorController = aoc;
        }
        
        #region Editor

#if UNITY_EDITOR
        public void SwapSpritesInAnimationsEditor()
        {
            SwapSpritesInAnimationsEditor(animationSheet);
        }
        
        public void SwapSpritesInAnimationsEditor(WearableSO so)
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

                ExportModifiedAnimationClip(clip, animationSheet.spriteAnimationsList[i]);
                
            }
        }
        private void ExportModifiedAnimationClip(AnimationClip originalClip, SpriteAnimations sprites)
        {
            if (originalClip == null)
            {
                Debug.LogError("Original AnimationClip is null!");
                return;
            }

            AnimationClip modifiedClip = new AnimationClip();
            AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(originalClip);

            var curveBindings = AnimationUtility.GetObjectReferenceCurveBindings(originalClip);

            foreach (var binding in curveBindings)
            {
                if (binding.propertyName != "m_Sprite")
                    continue;

                ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(originalClip, binding);

                ObjectReferenceKeyframe[] modifiedKeyframes = new ObjectReferenceKeyframe[keyframes.Length];

                for (int i = 0; i < keyframes.Length; i++)
                {
                    int spriteIndex = Mathf.Clamp(i, 0, sprites.animations.Count - 1);
                    modifiedKeyframes[i] = new ObjectReferenceKeyframe();
                    modifiedKeyframes[i].time = keyframes[i].time;
                    modifiedKeyframes[i].value = sprites.animations[spriteIndex];
                }

                AnimationUtility.SetObjectReferenceCurve(modifiedClip, binding, modifiedKeyframes);
            }

            AnimationUtility.SetAnimationClipSettings(modifiedClip, clipSettings);

            // Create a new folder
            string originalClipPath = AssetDatabase.GetAssetPath(originalClip);
            string directory = System.IO.Path.GetDirectoryName(originalClipPath);
            string newFolder = directory + "/ModifiedClips_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            System.IO.Directory.CreateDirectory(newFolder);

            // Generate a unique name for the modified clip
            string newClipName = originalClip.name + "_Modified.anim";
            string newClipPath = newFolder + "/" + newClipName;

            AssetDatabase.CreateAsset(modifiedClip, newClipPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        
#endif
        #endregion
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
              //  wearablesAnim.SwapSpritesInAnimationsEditor();
            }
        }
    }
#endif
}