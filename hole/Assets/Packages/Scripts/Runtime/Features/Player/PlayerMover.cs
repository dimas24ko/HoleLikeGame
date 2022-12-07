using DG.Tweening;
using Hole.Runtime.Features.Game;
using Hole.Runtime.Features.UI;
using UnityEngine;
using Zenject;

namespace Hole.Runtime.Features.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Transform player;

        [SerializeField] private float standartMovingSpeed;
        [SerializeField] private float biggerMovingSpeed;

        private Sequence setterSpeedSequence;
        private GameData gameData;

        private float actualSpeed;

        [Inject]
        public void Construct(GameData gameData) =>
            this.gameData = gameData;

        private void Awake()
        {
            joystick.Dragged += Move;
            joystick.Dragged += MovingRotate;

            actualSpeed = standartMovingSpeed;
        }

        private void OnDestroy()
        {
            joystick.Dragged -= Move;
            joystick.Dragged -= MovingRotate;

        }

        public void SetBiggerSpeed()
        {
            setterSpeedSequence?.Kill();

            setterSpeedSequence = DOTween.Sequence()
                .Append(DOVirtual.DelayedCall(0, () => actualSpeed = biggerMovingSpeed))
                .Append(DOVirtual.DelayedCall(gameData.BiggerSpeedTime, () => actualSpeed = standartMovingSpeed))
                .Play();
        }

        private void Move(Vector3 newPosition)
        {
            var targetPosition = new Vector3(transform.position.x + newPosition.x*actualSpeed, transform.position.y, transform.position.z + newPosition.y*actualSpeed);
            
            //transform.Translate(targetPosition * actualSpeed);

            transform.position = targetPosition;
        }

        private void MovingRotate(Vector3 newPosition) =>
            player.rotation = Quaternion.LookRotation(new Vector3(newPosition.x, 0, newPosition.y));
    }
}