
using UnityEngine;

namespace Shooter
{
    public class BaseObjectModel : MonoBehaviour
    {
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public MeshRenderer MeshRenderer;
        [HideInInspector] public Shader Shader;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            MeshRenderer = GetComponent<MeshRenderer>();
            Shader = GetComponent<Shader>();
        }

        public bool IsVisible(bool value)
        {
            MeshRenderer.enabled = value;
            return value;
        }
    }
}
