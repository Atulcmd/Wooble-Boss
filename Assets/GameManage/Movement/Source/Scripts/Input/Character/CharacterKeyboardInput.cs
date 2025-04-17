using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This character movement input class is an example of how to get input from a keyboard to control the character;
    public class CharacterKeyboardInput : CharacterInput
    {
        Joystick joystick;
        public string horizontalInputAxis = "Horizontal";
		public string verticalInputAxis = "Vertical";
		public KeyCode jumpKey = KeyCode.Space;

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;


        public void Start()
        {
            joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
        }

        public override float GetHorizontalMovementInput()
		{
			if(useRawInput)
				return joystick.direction.x;
			else
				return Input.GetAxis(horizontalInputAxis);
		}

		public override float GetVerticalMovementInput()
		{
            if (useRawInput)
                return joystick.direction.y;

            else
                return Input.GetAxis(verticalInputAxis);
		}

		public override bool IsJumpKeyPressed()
		{
			return Input.GetKey(jumpKey);
		}
    }
}
