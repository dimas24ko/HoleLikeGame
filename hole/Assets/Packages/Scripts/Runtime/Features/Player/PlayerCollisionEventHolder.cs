using System;
using Hole.Runtime.Features.Items;
using UnityEngine;

namespace Hole.Runtime.Features.Player
{
    public class PlayerCollisionEventHolder : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        public Action<ItemType> OnItemTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Item>())
            {
                var item = other.GetComponent<Item>();
                
                item.Animator.JumpIntoPlayer(playerData.ItemsAnchor);
                
                OnItemTriggered?.Invoke(item.Type);
            }
        }
    }
}