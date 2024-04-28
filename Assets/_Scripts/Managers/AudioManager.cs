using UnityEngine;

namespace BGS.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip stepInside, stepOutside,door;

        public void PlaySound(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

        public AudioClip SetStepSound()
        {
            return GameManager.Instance.isOutside ? stepOutside : stepInside;
        }

        public void PlayDoorSound()
        {
            PlaySound(door);
        }
        
    }
}