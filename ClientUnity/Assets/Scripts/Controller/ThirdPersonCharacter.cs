using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
	public int PlayerID;

    Vector3 v3InitPos_01 = new Vector3(-12.0f, 0.0f, -15.0f);
    Vector3 v3InitPos_02 = new Vector3(12.0f, 0.0f, 5.0f);

	[SerializeField] float m_MovingTurnSpeed = 360;
	[SerializeField] float m_StationaryTurnSpeed = 180;
	[SerializeField] float m_JumpPower = 12f;
	[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
	[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
	[SerializeField] float m_MoveSpeedMultiplier = 1f;
	[SerializeField] float m_AnimSpeedMultiplier = 1f;
	[SerializeField] float m_GroundCheckDistance = 0.1f;

	Rigidbody m_Rigidbody;
	Animator m_Animator;
	bool m_IsGrounded;
	float m_OrigGroundCheckDistance;
	const float k_Half = 0.5f;
	float m_TurnAmount;
	float m_ForwardAmount;
	Vector3 m_GroundNormal;
	float m_CapsuleHeight;
	Vector3 m_CapsuleCenter;
	CapsuleCollider m_Capsule;
	bool m_Crouching;
	public float DashSpeed;
	private Vector3 DashTarget;
	private Vector3 m_CamForward;
	private Vector3 m_Move;
	private bool isDash;
	public GameObject Spear;
	Transform m_Cam;
	public string InputStringH;
	public string InputStringV;
	public GameObject Animators;
	public AudioClip HitSound;
	public AudioClip DropSound;
	public AudioClip EatSound;
	public AudioClip WroundSound;
	public AudioClip AttackSound;
	public AudioClip DashSound;

    [SerializeField] SpearCollider m_SpearController;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Capsule = GetComponent<CapsuleCollider>();
		m_CapsuleHeight = m_Capsule.height;
		m_CapsuleCenter = m_Capsule.center;

		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		m_OrigGroundCheckDistance = m_GroundCheckDistance;

        if (PlayerID == 1)
            GameLogic.GetInstance().PlayerMediator.RegistPlayerController1(GetComponent<ThirdPersonCharacter>());
        else if (PlayerID == 2)
			GameLogic.GetInstance ().PlayerMediator.RegistPlayerController2 (GetComponent<ThirdPersonCharacter>());

		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
			Debug.Log ("GetCamera");
		}

        Init();
	}

    public void Init()
    {
        m_SpearController.Init();
        UpdateFruiltList();

        transform.position = PlayerID == 1 ? v3InitPos_01 : v3InitPos_02;
    }

	void Update()
	{
		if (isDash) 
		{
			transform.position = Vector3.Lerp (transform.position, DashTarget, Time.deltaTime * 5);
			if (Vector3.Distance (transform.position, DashTarget) < 1f) 
			{
				isDash = false;
			}
		}
	}


	public void Move(Vector3 move, bool crouch, bool jump)
	{

		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		move = transform.InverseTransformDirection(move);
		CheckGroundStatus();
		move = Vector3.ProjectOnPlane(move, m_GroundNormal);
		m_TurnAmount = Mathf.Atan2(move.x, move.z);
		m_ForwardAmount = move.z;

		ApplyExtraTurnRotation();

		// control and velocity handling is different when grounded and airborne:
		if (m_IsGrounded)
		{
			HandleGroundedMovement(crouch, jump);
		}
		else
		{
			HandleAirborneMovement();
		}

		ScaleCapsuleForCrouching(crouch);
		PreventStandingInLowHeadroom();

		// send input and other state parameters to the animator
		UpdateAnimator(move);
	}

	public void Dash()
	{
		DashTarget = transform.position + transform.forward * DashSpeed;
		GetComponent<AudioSource> ().PlayOneShot (DashSound);
		isDash = true;
	}

    public void WeaponCollider_Open()
    {
        Debug.LogWarning("WeaponCollider_Open");
        m_SpearController.SwitchCollider(true);
    }

    public void WeaponCollider_Close()
    {
        Debug.LogWarning("WeaponCollider_Close");
        m_SpearController.SwitchCollider(false);
    }

	public void Attack()
	{
        GameLogic.GetInstance().PlayerProxy.SwitchState_Attack(PlayerID, true);
		Animators.GetComponent<Animator> ().Play("attack");
		GetComponent<AudioSource> ().PlayOneShot (AttackSound);
	}

    public void Eat()
    {
        Debug.Log("Eat / PlayerID: " + PlayerID);

        if (SuccessGetScore())
        {
            Debug.LogError("SuccessGetScore");
			GameLogic.GetInstance().WantedProxy.CreateNewList(PlayerID);
			GetComponent<AudioSource> ().PlayOneShot (EatSound);
        }
		else
		{
			GetComponent<AudioSource> ().PlayOneShot (WroundSound);
		}

        GameLogic.GetInstance().PlayerProxy.CleanFoodList(PlayerID);
    }

    bool SuccessGetScore()
    {
        string[] tmpAryListName = GameLogic.GetInstance().PlayerProxy.GetPlayFruitListName(PlayerID);
        string[] tmpAryListQuetion = GameLogic.GetInstance().WantedProxy.GetQuestionForPlayer(PlayerID);
        int iDataLength = tmpAryListName.Length;

        for (int i = 0; i < tmpAryListName.Length; i++)
            Debug.Log("AryListName ["+i+"]: " + tmpAryListName[i]);

        for (int i = 0; i < tmpAryListQuetion.Length; i++)
            Debug.Log("tmpAryListQuetion [" + i + "]: " + tmpAryListQuetion[i]);

        if (tmpAryListName.Length != tmpAryListQuetion.Length)
        {
            Debug.LogError("Question length not equal to Fruit list count!!!");
            return false;
        }

        for (int i = 0; i < iDataLength; i++)
        {
            if (tmpAryListName[i] != tmpAryListQuetion[i])
                return false;
        }

        return true;
    }

    public void AttackComplete ()
	{
        GameLogic.GetInstance().PlayerProxy.SwitchState_Attack(PlayerID, false);
	}

	void ScaleCapsuleForCrouching(bool crouch)
	{
		if (m_IsGrounded && crouch)
		{
			if (m_Crouching) return;
			m_Capsule.height = m_Capsule.height / 2f;
			m_Capsule.center = m_Capsule.center / 2f;
			m_Crouching = true;
		}
		else
		{
			Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
			float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
			if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
			{
				m_Crouching = true;
				return;
			}
			m_Capsule.height = m_CapsuleHeight;
			m_Capsule.center = m_CapsuleCenter;
			m_Crouching = false;
		}
	}

	void PreventStandingInLowHeadroom()
	{
		// prevent standing up in crouch-only zones
		if (!m_Crouching)
		{
			Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
			float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
			if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
			{
				m_Crouching = true;
			}
		}
	}


	void UpdateAnimator(Vector3 move)
	{
		// update the animator parameters
		m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
		m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
		m_Animator.SetBool("Crouch", m_Crouching);
		m_Animator.SetBool("OnGround", m_IsGrounded);
		if (!m_IsGrounded)
		{
			m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
		}

		// calculate which leg is behind, so as to leave that leg trailing in the jump animation
		// (This code is reliant on the specific run cycle offset in our animations,
		// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
		float runCycle =
			Mathf.Repeat(
				m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
		float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
		if (m_IsGrounded)
		{
			m_Animator.SetFloat("JumpLeg", jumpLeg);
		}

		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (m_IsGrounded && move.magnitude > 0)
		{
			m_Animator.speed = m_AnimSpeedMultiplier;
		}
		else
		{
			// don't use that while airborne
			m_Animator.speed = 1;
		}
	}


	void HandleAirborneMovement()
	{
		// apply extra gravity from multiplier:
		Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
		m_Rigidbody.AddForce(extraGravityForce);

		m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
	}


	void HandleGroundedMovement(bool crouch, bool jump)
	{
		// check whether conditions are right to allow a jump:
		if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
		{
			// jump!
			m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
			m_IsGrounded = false;
			m_Animator.applyRootMotion = false;
			m_GroundCheckDistance = 0.1f;
		}
	}

	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}


	public void OnAnimatorMove()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (m_IsGrounded && Time.deltaTime > 0)
		{
			Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

			// we preserve the existing y part of the current velocity.
			v.y = m_Rigidbody.velocity.y;
			m_Rigidbody.velocity = v;
		}
	}


	void CheckGroundStatus()
	{
		RaycastHit hitInfo;
#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
		{
			m_GroundNormal = hitInfo.normal;
			m_IsGrounded = true;
			m_Animator.applyRootMotion = true;
		}
		else
		{
			m_IsGrounded = false;
			m_GroundNormal = Vector3.up;
			m_Animator.applyRootMotion = false;
		}
	}
	private void FixedUpdate()
	{
		// read inputs
		float h = CrossPlatformInputManager.GetAxis(InputStringH);
		float v = CrossPlatformInputManager.GetAxis(InputStringV);

		// calculate move direction to pass to character
		if (m_Cam != null)
		{
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
			m_Move = v*m_CamForward + h*m_Cam.right;
		}
		else
		{
			m_Move = v*Vector3.forward + h*Vector3.right;
		}
		Move(m_Move, false, false);
	}


	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player" && isDash) 
		{
			//Get Hit
			Debug.Log(collision.transform.name);
			GetComponent<AudioSource> ().PlayOneShot (HitSound);
			collision.gameObject.GetComponent<AudioSource> ().PlayOneShot (DropSound);
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.transform.name == "Walls" && isDash) 
		{
			//Get Hit
			isDash = false;
		}
	}

    public void UpdateFruiltList()
    {
        Debug.LogWarning("FruiltList / Player ID: " + (PlayerID));
        string[] sAryFruitName = GameLogic.GetInstance().PlayerProxy.GetPlayFruitListName(PlayerID);

        m_SpearController.DisplayFruilt(sAryFruitName);
    }
}
