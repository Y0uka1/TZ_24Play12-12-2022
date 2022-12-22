using System;
using UnityEngine;

namespace General
{
    public class DestroyAreaService:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}