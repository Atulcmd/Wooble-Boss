#if PLAYMAKER

using System.Collections;
using HutongGames.PlayMaker;

namespace SensorToolkit.PlayMaker
{
    [ActionCategory("Sensors")]
    [Tooltip("Sets a steering rigs destination position or direction to face.")]
    public class SetSteeringTargets : SensorToolkitComponentAction<SteeringRig>
    {
        [RequiredField]
        [CheckForComponent(typeof(SteeringRig))]
        [Tooltip("The game object owning the steering rig.")]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        [Tooltip("Optional. The position that should be moved to.")]
        public FsmVector3 destinationPosition;

        [UIHint(UIHint.Variable)]
        [Tooltip("Optional. The direction that should be faced towards.")]
        public FsmVector3 directionToFace;

        [Tooltip("If checked will clear the direction to face setting. Will cause the object to stop strafing.")]
        public FsmBool ClearDirectionToFace;

        [Tooltip("Set steering targets each frame.")]
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            destinationPosition = null;
            directionToFace = null;
            ClearDirectionToFace = false;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            doCheck();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            doCheck();
        }

        void doCheck()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject))) return;

            if (destinationPosition != null)
            {
                steeringRig.Destination = destinationPosition.Value;
            }
            if (directionToFace != null)
            {
                steeringRig.DirectionToFace = directionToFace.Value;
            }
            if (ClearDirectionToFace.Value == true)
            {
                steeringRig.ClearDirectionToFace();
            }
        }
    }
}

#endif