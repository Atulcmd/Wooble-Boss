using UnityEngine;
using System.Collections;

namespace SensorToolkit.Example
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject ToFollow;
        public float Speed;

        Vector3 offset;

        void Start()
        {
            offset = transform.position - ToFollow.transform.position;
        }

        void LateUpdate()
        {
            if (ToFollow == null) return;

            var targetPos = ToFollow.transform.position + offset;
            Vector3 vector3 = new Vector3(0f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(vector3, targetPos, Time.deltaTime * Speed);
        }
    }
}