using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class BaseObjectModel : MonoBehaviour
    {
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public MeshRenderer MeshRenderer;
        [HideInInspector] public Shader Shader;
        [HideInInspector] public Collider Collider;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            MeshRenderer = GetComponent<MeshRenderer>();
            Shader = GetComponent<Shader>();
            Collider = GetComponent<Collider>();
        }

        public bool IsVisible(bool value)
        {
            MeshRenderer.enabled = value;
            if (GetComponentsInChildren<MeshRenderer>() != null)
            {
                MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();
                foreach (var item in children)
                {
                    item.enabled = value;
                }
            }
            return value;
        }
    }
}
