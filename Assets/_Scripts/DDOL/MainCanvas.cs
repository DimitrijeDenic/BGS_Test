using UnityEngine;

namespace BGS.DDOL
{
    public class MainCanvas : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
