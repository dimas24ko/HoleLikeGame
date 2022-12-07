using System;
using Hole.Runtime.Features.Items;
using Hole.Runtime.Features.Score;
using Hole.Runtime.Services.Timer;
using UnityEngine;
using Zenject;

namespace Hole.Runtime.Features.Player
{
    public class PlayerCollisionSubscriber : MonoBehaviour
    {
        [SerializeField] 
        private PlayerCollisionEventHolder collisionEventHolder;
        
        [SerializeField] 
        private PlayerMover playerMover;

        private ScoreContainer scoreContainer;
        private LifeTimer timer;

        [Inject]
        public void Construct(ScoreContainer scoreContainer, LifeTimer timer)
        {
            this.scoreContainer = scoreContainer;
            this.timer = timer;
        }
        
        private void Awake() => 
            collisionEventHolder.OnItemTriggered += AnalyzeCollision;

        private void OnDestroy() => 
            collisionEventHolder.OnItemTriggered -= AnalyzeCollision;

        private void AnalyzeCollision(ItemType type)
        {
            switch (type)
            {
                case ItemType.Simple:
                    scoreContainer.IncreaseScore();
                    break;
                case ItemType.SpeedBuster:
                    playerMover.SetBiggerSpeed();
                    break;
                case ItemType.TimeBuster:
                    timer.AddTime();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}