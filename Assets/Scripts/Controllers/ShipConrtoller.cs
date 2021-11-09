using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Space
{
    public class ShipConrtoller : MonoBehaviour
    {
        // ��������
        CharacterController ship;
        // ������ � ������� �������� ������� ��� �� � ����
        [SerializeField]private float radiusNoClick = 3f;
        // ���������� Target
        private Vector3 target = Vector3.zero;
        // ������ �����������
        private Vector3 direction;
        // �������� ��������
        [SerializeField] private float speedRotation = 10f;
        // �������� ������������
        [SerializeField] private float speedMove = 30f;
        // ������ ���������, �� ����� ��� ���
        private bool onPlace = true;
        // ��������
        [SerializeField] GameObject jetStream;
        MeshRenderer[] jetStreamRenderers;


        // ���������
        private ShipState _shipState;

        void Start()
        {
            // �������� ���������
            ship = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
            if (jetStream)
            {
                jetStreamRenderers = jetStream.GetComponentsInChildren<MeshRenderer>();            }
        }

        public void SpaceUpdate()
        {
            ShipMove();
        }

        private void ShipMove()
        {
            if (!onPlace)
            {
                // ��������� ������ �����������
                direction = target - this.transform.position;
                // �����������, ��� �� �������� ������� �� � �����, � �����
                direction = new Vector3(direction.x, 0, direction.z);
                direction.Normalize();

                // ��������������
                Quaternion look = Quaternion.LookRotation(direction);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime * speedRotation);

                // ���������
                ship.Move(direction * Time.deltaTime * speedMove);

                if ((Mathf.Abs(transform.position.x - target.x) < radiusNoClick) &&
                (Mathf.Abs(transform.position.z - target.z) < radiusNoClick))
                {
                    OnPlaceTrue();
                }
                // �������� � ��������
                _shipState = ShipState.Flying;
            }
            else
                // �������� � ��������� "�����"
                _shipState = ShipState.Idle;

            if (jetStream)
            {
                // �������� ������ �������� � ����������� �� ���������
                if (_shipState == ShipState.Flying)
                {
                    foreach (var item in jetStreamRenderers)
                    {
                        item.enabled = true;
                    }
                }
                    
                else if (_shipState == ShipState.Idle)
                {
                    foreach (var item in jetStreamRenderers)
                    {
                        item.enabled = false;
                    }
                }
            }
        }

        public void GetTarget(Vector3 target)
        {
            // �������� ������� Target
            if ((Mathf.Abs(transform.position.x - target.x) >= radiusNoClick) &&
            (Mathf.Abs(transform.position.z - target.z) >= radiusNoClick))
            {
                this.target = target;
                // ������ ��� �������� �� �� �����
                onPlace = false;
            }
            else onPlace = true;
        }

        public void OnPlaceTrue()
        {
            onPlace = true;
        }
    }

}
