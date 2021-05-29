using System;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.GoodItem))
        {
            GameManager.Instance.RemoveLive();
        }
        
        Destroy(other.gameObject);
    }
}
