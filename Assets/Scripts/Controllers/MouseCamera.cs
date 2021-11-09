using SpaceLegend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Space
{
    [RequireComponent(typeof(Camera))]
    public sealed class MouseCamera : MonoBehaviour
    {
        private Transform target;
        private Vector3 targetPosition;
        [SerializeField] private LayerMask mask;
        [SerializeField] private PlayerShip playerShip;
        RaycastHit hit;
        [SerializeField] private Camera camera;

        private void Start()
        {
            if (!camera) camera = GetComponent<Camera>();
            targetPosition = new Vector3();
            if (!playerShip) playerShip = FindObjectOfType<PlayerShip>();
        }

        public void SpaceUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    targetPosition = hit.point;
                    playerShip.GetTarget(targetPosition);
                }
            }
        }
    }
}

