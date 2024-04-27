using BGS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace BGS.Gameplay
{
    public class SceneSetup : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private Vector2 playerStartPos1, playerStartPos2;
        [SerializeField] private bool camFollowPlayer;
        [SerializeField] private UnityEvent customSetup;
        private void Start()
        {
            _camera = Camera.main;

            if (GameManager.Instance.isOutside)
                Player.Instance.transform.position = GameManager.Instance.exitingShop ? playerStartPos2 : playerStartPos1;
            else
                Player.Instance.transform.position = playerStartPos1;

            customSetup?.Invoke();
            
            if (!camFollowPlayer) return;
            _camera!.GetComponent<CameraFollow>().target = Player.Instance.transform;
        }
    }
}