using UnityEngine;

namespace SpaceLegend
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        protected PlayerData playerData;
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        protected abstract void Interaction();

        private void Start()
        {
            Action();
        }

        public void Action()
        {
    
        }
    }
}