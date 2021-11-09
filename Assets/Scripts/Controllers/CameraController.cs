using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceLegend
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] PlayerShip ship;
       // private Vector3 offset;

        public Transform target;
        public float smooth = 5.0f;
        public Vector3 offset = new Vector3(0, 2, -5);

        void Start()
        {
            if (!ship) ship = FindObjectOfType<PlayerShip>();
            offset = transform.position - ship.transform.position;
        }

        public void SpaceUpdate()
        {
            //Debug.Log(target.position);
            transform.position = Vector3.Lerp(transform.position, ship.transform.position + offset, Time.deltaTime * smooth);
            //transform.position = ship.transform.position + offset;
        }

    }
}