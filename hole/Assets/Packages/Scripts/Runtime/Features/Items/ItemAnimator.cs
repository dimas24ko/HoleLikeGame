using DG.Tweening;
using UnityEngine;

namespace Hole.Runtime.Features.Items
{
    public class ItemAnimator : MonoBehaviour
    {
        [SerializeField] private float jumpPower;
        [SerializeField] private float jumpTime;
        
        public void JumpIntoPlayer(Transform playerAnchor)
        {
            transform
                .DOJump(playerAnchor.position, jumpPower, 1, jumpTime)
                .OnComplete(()=> Destroy(gameObject));
        }
    }
}