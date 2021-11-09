using Space;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceLegend
{
    public abstract class Player : MonoBehaviour
    {
        // Персонаж
        CharacterController ship;
        // Радиус в котором персонаж считает что он у цели
        [SerializeField] private float radiusNoClick = 3f;
        // Координаты Target
        private Vector3 target = Vector3.zero;
        // Вектор перемещения
        private Vector3 direction;
        // Скорость поворота
        [SerializeField] private float speedRotation = 10f;
        // Скорость передвижения
        [SerializeField] private float speedMove = 30f;
        // Маркер персонажа, на месте или нет
        private bool onPlace = true;
        // Анимации
        [SerializeField] GameObject jetStream;
        MeshRenderer[] jetStreamRenderers;

        // Состояние
        private ShipState _shipState;

        void Start()
        {
            // Получаем персонажа
            ship = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
            if (jetStream)
            {
                jetStreamRenderers = jetStream.GetComponentsInChildren<MeshRenderer>();
            }
        }

        //public void Update()
        //{
        //    mouseCamera.SpaceUpdate();
        //    ShipMove();
        //}

        protected void ShipMove()
        {
            if (!onPlace)
            {
                // Вычисляем вектор перемещения
                direction = target - this.transform.position;
                // Нормализуем, что бы персонаж смотрел не в землю, а прямо
                direction = new Vector3(direction.x, 0, direction.z);
                direction.Normalize();

                // Поворачиваемся
                Quaternion look = Quaternion.LookRotation(direction);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime * speedRotation);

                // Двигаемся
                if(!ship) ship = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
               // if (ship) 
                    ship.Move(direction * Time.deltaTime * speedMove);

                if ((Mathf.Abs(transform.position.x - target.x) < radiusNoClick) &&
                (Mathf.Abs(transform.position.z - target.z) < radiusNoClick))
                {
                    OnPlaceTrue();
                }
                // Персонаж в движении
                _shipState = ShipState.Flying;
            }
            else
                // Персонаж в состоянии "покоя"
                _shipState = ShipState.Idle;

            //if (jetStream)
            //{
            //    // Включаем нужную анимацию в зависимости от состояния
            //    if (_shipState == ShipState.Flying)
            //    {
            //        foreach (var item in jetStreamRenderers)
            //        {
            //            item.enabled = true;
            //        }
            //    }

            //    else if (_shipState == ShipState.Idle)
            //    {
            //        foreach (var item in jetStreamRenderers)
            //        {
            //            item.enabled = false;
            //        }
            //    }
            //}
        }

        public void GetTarget(Vector3 target)
        {
            // Проверка позиции Target
            if ((Mathf.Abs(transform.position.x - target.x) >= radiusNoClick) &&
            (Mathf.Abs(transform.position.z - target.z) >= radiusNoClick))
            {
                this.target = target;
                //  персонаж не на месте
                onPlace = false;
            }
            else onPlace = true;
        }

        public void OnPlaceTrue()
        {
            onPlace = true;
        }

        //protected void Move()
        //{
        //    float moveHorizontal = Input.GetAxis("Horizontal");
        //    float moveVertical = Input.GetAxis("Vertical");

        //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //    _rigidbody.AddForce(movement * Speed);
        //}
    }
}