using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
		private GameObject planet;
		private Rigidbody m_Rb;

        
        private void Start()
        {
			planet = GameObject.Find ("/1Orbit/Sphere");
			m_Rb = GetComponent<Rigidbody> ();


            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
			Vector3 dg = (planet.transform.position - transform.position).normalized;
			Vector3 g = dg * 100;

			transform.parent.up = -dg;

			Vector3 myForward = Vector3.ProjectOnPlane(transform.forward, -dg);
			Vector3 myRight = Vector3.Cross(myForward, dg); Vector3.ProjectOnPlane(transform.forward, -dg);

			//Debug.DrawRay (transform.position, myForward, Color.blue);
			//Debug.DrawRay (transform.position, -dg, Color.green);

			//transform.rotation = Quaternion.LookRotation(myForward,-dg);

			m_Rb.AddForce(g*m_Rb.mass);


            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);
			Vector3 m_CamRight =   Vector3.Cross(m_CamForward, dg).normalized;

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                //m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
				m_CamForward = Vector3.ProjectOnPlane (m_Cam.forward, -dg).normalized;

				Debug.DrawRay (transform.position, m_CamForward, Color.yellow);
				Debug.DrawRay (transform.position, m_CamRight, Color.gray);

				//m_Move = v*m_CamForward + h*m_CamRight;
				m_Move = v*myForward + h*myRight;
				Debug.DrawRay (transform.position, m_Move, Color.red);

            }
            else
            {
                // we use world-relative directions in the case of no main camera
                //m_Move = v*Vector3.forward + h*Vector3.right;
            }
//if !MOBILE_INPUT
			// walk speed multiplier
	        //if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
//endif

            // pass all parameters to the character control script
			float forwardAmount = Vector3.Dot (m_Move, m_CamForward); //

			float hProj = Vector3.Dot (m_Move, m_CamRight);
			float turnAmount = amount( Vector3.Angle (m_CamForward, m_Move), hProj, forwardAmount) ;
			m_Character.Move(m_Move.magnitude, forwardAmount, turnAmount, crouch, m_Jump);

           
            m_Jump = false;
        }

		private float amount(float angle, float x, float y){

			if (y < 0 && x > 0) { // 
				return angle;
			} else if (y < 0 && x < 0) { // 
				Debug.Log (angle);
				return 90 - angle - 90;
			} else if (x < 0) { // 2Q
				return -angle;
			} else if (x > 0) { // 1Q
				return angle;
			} else if (x == 0 && y < 0) {
				return 0;
			} else {
				return 0;
			}

		}

    }
}
