using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class CameraPosition : MonoBehaviour
    {
        private Transform _player;
        private Transform _camera;
        private float sensitivity = 2f;
        private float X, Y;
        float limit = 80;
        public float distance = 1.5f;
        Vector3 offset;
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform;
            limit = Mathf.Abs(limit);
            if (limit > 90) limit = 90;
            offset = new Vector3(offset.x, offset.y, distance);
            transform.position = _player.position + offset;
        }


        void Update()
        {
            //transform.localRotation *= Quaternion.Euler(-xRot, 0f, 0f);
            ////transform.position = new Vector3 (_player.position.x, _player.position.y + 1.5f, _player.position.z - 1.5f) ;
            ////transform.RotateAround(_player.position, _player.position, yRot);
            ////_player.rotation = new Quaternion(_player.rotation.x, transform.rotation.y, _player.rotation.z, _player.rotation.w);
            //X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            //Y += Input.GetAxis("Mouse Y") * sensitivity;
            //Y = Mathf.Clamp(Y, -limit, limit);
            //transform.localEulerAngles = new Vector3(-Y, X, 0);
            //transform.position = transform.localRotation * offset + _player.position;

            //float xRot = Input.GetAxis("Mouse Y") * sensitivity;
            //float yRot = Input.GetAxis("Mouse X") * sensitivity;
            //_player.localRotation *= Quaternion.Euler(0f, yRot, 0f);
            //X = transform.localEulerAngles.y + yRot;
            //Y += xRot;
            //Y = Mathf.Clamp(Y, -limit, limit);
            //transform.localEulerAngles = new Vector3(Y, X, 0);
            //transform.position = transform.localRotation * offset + _player.position;
        }
    }
}
