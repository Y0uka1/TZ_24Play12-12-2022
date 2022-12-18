using System;
using UnityEngine;

public class CollisionToEvent : MonoBehaviour
{
    public Action<Collision> OnCubeCollide;
    
    private void OnCollisionEnter(Collision collision)
    {
        OnCubeCollide?.Invoke(collision);
    }

}