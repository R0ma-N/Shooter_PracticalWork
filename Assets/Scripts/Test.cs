using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Transform target;
        public Camera _camera;
        RaycastHit hit;
    bool gotTarget;
    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        //сюда запишется инфо о пересечении луча, если оно будет
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        //Ray ray = new Ray(transform.position, transform.forward);

        //пускаем луч
        Physics.Raycast(ray, out hit);

            Debug.DrawLine(ray.origin, ray.direction * 10, Color.red);
        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            //если луч не попал в цель
            if (hit.collider.gameObject == target.gameObject)
            {
                Debug.Log("Попадаю во врага!!!");
                if (Input.GetKeyDown(KeyCode.Mouse1) && !gotTarget)
                {
                    target.transform.parent = Camera.main.transform;
                    gotTarget = true;
                }
                else if (Input.GetKeyUp(KeyCode.Mouse1) && gotTarget)
                {
                    target.transform.DetachChildren();
                }
            }
            //если луч попал в цель
            //else
            //{
            //    Debug.Log("Попадаю во врага!!!");
            //}
            //просто для наглядности рисуем луч в окне Scene
        }
    }
}
