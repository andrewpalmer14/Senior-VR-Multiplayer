using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {
	
	[SerializeField] const int walkableLayerNumber = 8;
	[SerializeField] const int enemyLayerNumber = 9;
	[SerializeField] const int unknownLayerNumber = 10;
	[SerializeField] const int objectHitLayerNumber = 11;

	[SerializeField] float stopRadius = 0.25f;
	[SerializeField] float attackMeleeStopRadius = 0.85f;
	//[SerializeField] float attackRangedStopRadius = 10.0f;
	//[SerializeField] float attackSpellStopRadius = 7.0f;

	private float possibleDamageLossPercentage = 0.75f;
	private float attackMeleeDamage = 25f;
	private float attackRangedDamage = 1.25f;
	private float attackSpellDamage = 1.75f;

	private GameObject currentEnemyTarget = null;
	private Enemy closestEnemy = null;
	//private Array enemies = null;

	private bool playerIsAttacking = false;
	private bool usingMelee = true;
	private bool usingRanged = false;
	private bool usingSpell = false;
	private bool usingControllerMovement = true;
	private bool m_Jump = false;                      // the world-relative desired move direction, calculated from the camForward and user input.
	private bool inQuestChat = false;

	private UnityEngine.AI.NavMeshAgent agent;
    private ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    private CameraRaycaster cameraRaycaster;
    private Vector3 currentClickTarget;
	private new Camera camera;
	private Animator animator;

	private Player player;
        
    private void Start() {
		player = GameObject.FindObjectOfType<Player>();//GetComponent<Player>();
		if (player != null) {
			//enemies = FindObjectsOfType<Enemy>();
			//Debug.Log("enemies: " + this.enemies.ToString());
			camera = Camera.main;
			if (camera == null) {
				camera = FindObjectOfType<Camera>();
			}
			if (Camera.main != null) {
				cameraRaycaster = Camera.main.GetComponentInParent<CameraRaycaster>();
				this.cameraRaycaster.mouseClickObservers += OnDelegateCalled;
			}
			if (cameraRaycaster == null) {
				cameraRaycaster = FindObjectOfType<CameraRaycaster>();
			}
			agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
			m_Character = GetComponent<ThirdPersonCharacter>();
			animator = GetComponent<Animator>();
			currentClickTarget = transform.position;

			agent.updateRotation = false;
			agent.updatePosition = true;
		}
    }

	private void Update() {
		if (player == null) {
			Start();
		} else {
			if (!m_Jump) {
				//m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
			if (CrossPlatformInputManager.GetButtonUp("Toggle Movement")) {
				usingControllerMovement = !usingControllerMovement;		// toggles movement controls
				currentClickTarget = this.transform.position;
				agent.SetDestination(this.transform.position);
			}
		}
	}

    // Fixed update is called in sync with physics
    private void FixedUpdate() {
			if (usingControllerMovement) {
				Cursor.visible = false;
				HandleControllerMovement();
			} else {
				Cursor.visible = true;
				HandleMouseMovement();
			}
			m_Jump = false;		//TODO: decide if jump is worth having
    }

	// Checks for left mouse click and if ground is walkable, moves player
	private void HandleMouseMovement() {
		if (playerIsAttacking && !inQuestChat) {	// attack movement
			MoveToAttackPosition();
		} else if (!inQuestChat) {		// regular walking movement
			agent.SetDestination(currentClickTarget);
			m_Character.Move(agent.desiredVelocity, false, m_Jump);
//			if ((currentClickTarget - this.transform.position).magnitude >= /*stopRadius*/this.agent.stoppingDistance) {
//				agent.SetDestination(currentClickTarget);
//				m_Character.Move(/*currentClickTarget - transform.position*/agent.desiredVelocity, false, m_Jump);
//			} else {
//				agent.SetDestination(this.transform.position);
//				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
//			}
		}
	}

	// Handles movement when player is using controller or in mode for WASD controls
	private void HandleControllerMovement() {
		//animator.SetBool("newCrouch", false);
		agent.SetDestination(this.transform.position);
		currentClickTarget = this.transform.position;
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		if (CrossPlatformInputManager.GetButton("Attack")) {
			var enemies = FindObjectsOfType<Enemy>();
			if (enemies.Length > 0) {
				foreach (Enemy enemy in enemies) {
					if (closestEnemy == null) {
						closestEnemy = enemy;
						//print("initial closest enemy set as: " + enemy.ToString());
					} else {
						if ((enemy.transform.position - this.transform.position).magnitude < (closestEnemy.transform.position - this.transform.position).magnitude) {
							closestEnemy = enemy;
							//print("closer enemy found: " + enemy.ToString());
						}
					}
				}
				if (!inQuestChat) {
					currentEnemyTarget = closestEnemy.gameObject;
					currentClickTarget = currentEnemyTarget.transform.position;
					agent.SetDestination(currentClickTarget);
					playerIsAttacking = true;
				}
			} else {
				currentEnemyTarget = null;
				currentClickTarget = this.transform.position;
				agent.SetDestination(currentClickTarget);
				playerIsAttacking = false;
			}
		} else {
			currentEnemyTarget = null;
			currentClickTarget = this.transform.position;
			agent.SetDestination(currentClickTarget);
			playerIsAttacking = false;
		}

		if (playerIsAttacking && !inQuestChat) {
			animator.SetBool("newCrouch", false);
			ControllerMoveToAttackPosition();
		} else {
			animator.SetBool("newCrouch", false);
			if (!inQuestChat) {
				if (camera != null) {
					m_Character.Move(v*/*Vector3.forward*/this.camera.transform.forward + h*/*Vector3.right*/this.camera.transform.right, false, m_Jump);
				} else {
					camera = FindObjectOfType<Camera>();
				}
			} else {
					m_Character.Move(Vector3.zero, false, false);
			}
		}
	}

	// controller method of moving to attack position and then attacking
	// TODO: more redundant code... I need to spend a day just making this nice and clean
	void ControllerMoveToAttackPosition() {
		if (usingMelee) {
			if ((closestEnemy.transform.position - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackMeleeStopRadius*/) {
				//agent.SetDestination(currentClickTarget);
				m_Character.Move(/*closestEnemy.transform.position - this.transform.position*/agent.desiredVelocity, false, m_Jump);
			} else {
				//agent.SetDestination(this.transform.position);
				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
				AttackEnemy();
			}
		} else if (usingRanged) {
			if ((closestEnemy.transform.position - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackRangedStopRadius*/) {
				//agent.SetDestination(currentClickTarget);
				m_Character.Move(/*closestEnemy.transform.position - this.transform.position*/agent.desiredVelocity, false, m_Jump);
			} else {
				//agent.SetDestination(this.transform.position);
				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
				AttackEnemy();
			}
		} else if (usingSpell) {
			if ((closestEnemy.transform.position - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackSpellStopRadius*/) {
				//agent.SetDestination(currentClickTarget);
				m_Character.Move(/*closestEnemy.transform.position - this.transform.position*/agent.desiredVelocity, false, m_Jump);
			} else {
				//agent.SetDestination(this.transform.position);
				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
				AttackEnemy();
			}
		}
	}

	// move to enemy, stop when close enough
	// TODO: redundant code... using a function to simplify this
	void MoveToAttackPosition() {
		currentClickTarget = currentEnemyTarget.transform.position;
		agent.SetDestination(currentClickTarget);
		agent.transform.LookAt(currentEnemyTarget.transform);
		if (usingMelee || usingSpell || usingRanged) {
			if (agent.remainingDistance > 0.0f + agent.stoppingDistance) {
				//agent.SetDestination(this.currentClickTarget);
				m_Character.Move(agent.desiredVelocity, false, m_Jump);
				animator.SetBool("newCrouch", false);
			} else {
				//agent.SetDestination(this.transform.position);
				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
				AttackEnemy();
			}
		}
//		if (usingMelee) {
//			if ((currentClickTarget - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackMeleeStopRadius*/) {
//				agent.SetDestination(this.currentClickTarget);
//				m_Character.Move(/*currentClickTarget - transform.position*/agent.desiredVelocity, false, m_Jump);
//			} else {
//				agent.SetDestination(this.transform.position);
//				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
//				AttackEnemy();
//			}
//		} else if (usingRanged) {
//			if ((currentClickTarget - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackRangedStopRadius*/) {
//				agent.SetDestination(this.currentClickTarget);
//				m_Character.Move(/*currentClickTarget - transform.position*/agent.desiredVelocity, false, m_Jump);
//			} else {
//				agent.SetDestination(this.transform.position);
//				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
//				AttackEnemy();
//			}
//		} else if (usingSpell) {
//			if ((currentClickTarget - this.transform.position).magnitude >= this.agent.stoppingDistance/*attackSpellStopRadius*/) {
//				agent.SetDestination(this.currentClickTarget);
//				m_Character.Move(/*currentClickTarget - transform.position*/agent.desiredVelocity, false, m_Jump);
//			} else {
//				agent.SetDestination(this.transform.position);
//				m_Character.Move(/*Vector3.zero*/agent.desiredVelocity, false, m_Jump);
//				AttackEnemy();
//			}
//		}
	}

	public void DealDamageToEnemy() {
		var wrathDamage = player.GetWrathLvl()/100.0f;
		var damage = UnityEngine.Random.Range((attackMeleeDamage + wrathDamage) - ((attackMeleeDamage + wrathDamage) * possibleDamageLossPercentage), (attackMeleeDamage+ wrathDamage));
		Debug.Log("player doing damage: " + damage);
		if (!closestEnemy.GetEnemyDead()) {
			closestEnemy.DealDamageToEnemy(damage);
		}
	}

	void AttackEnemy() {
		animator.SetBool("newCrouch", true);
		m_Character.transform.LookAt(currentEnemyTarget.transform);
		agent.transform.LookAt(currentEnemyTarget.transform);
		if (usingMelee && !closestEnemy.GetEnemyDead()) {
			//closestEnemy.DealDamageToEnemy(attackMeleeDamage);
		} else if (usingRanged && !closestEnemy.GetEnemyDead()) {
			//closestEnemy.DealDamageToEnemy(attackRangedDamage);
		} else if (usingSpell && !closestEnemy.GetEnemyDead()) {
			//closestEnemy.DealDamageToEnemy(attackSpellDamage);
		}
	}

	public void SetCurrentTargetToNull() {
		animator.SetBool("newCrouch", false);
		this.currentClickTarget = this.transform.position;
		this.closestEnemy = null;
		this.playerIsAttacking = false;
	}

	void OnDelegateCalled(RaycastHit hit, int newLayer) {
		/*if (Input.GetMouseButton(0)) {
			switch (this.cameraRaycaster.layerHit) {
			case Layer.Walkable:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				currentClickTarget = cameraRaycaster.hit.point;
				closestEnemy = null;
				break;
			case Layer.Enemy:
				playerIsAttacking = true;
				currentEnemyTarget = cameraRaycaster.hit.transform.gameObject;
				closestEnemy = cameraRaycaster.hit.transform.GetComponent<Enemy>();
				currentClickTarget = currentEnemyTarget.transform.position;
				break;
			default:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				closestEnemy = null;
				currentClickTarget = this.transform.position;
				return;
			}
		}*/
		if (!usingControllerMovement) {
			switch(newLayer) {
			case walkableLayerNumber:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				currentClickTarget = hit.point;
				closestEnemy = null;
				break;
			case enemyLayerNumber:
				playerIsAttacking = true;
				currentEnemyTarget = hit.transform.gameObject;
				closestEnemy = hit.transform.GetComponent<Enemy>();
				currentClickTarget = currentEnemyTarget.transform.position;
				break;
			case unknownLayerNumber:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				currentClickTarget = this.transform.position;
				closestEnemy = null;
				break;
			case objectHitLayerNumber:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				currentClickTarget = this.transform.position;
				closestEnemy = null;
				break;

				default:
				playerIsAttacking = false;
				currentEnemyTarget = null;
				currentClickTarget = this.transform.position;
				closestEnemy = null;
				return;
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.black;
		Gizmos.DrawLine(this.transform.position, this.currentClickTarget);
		Gizmos.DrawSphere(this.currentClickTarget, 0.1f);
		if (currentEnemyTarget != null) {
			//Vector3 gizmoRanged = this.currentEnemyTarget.transform.position - (this.currentEnemyTarget.transform.position - this.transform.position).normalized * attackRangedStopRadius;
			//Vector3 gizmoSpell = this.currentEnemyTarget.transform.position - (this.currentEnemyTarget.transform.position - this.transform.position).normalized * attackSpellStopRadius;
			//Vector3 gizmoAttack = this.currentEnemyTarget.transform.position - (this.currentEnemyTarget.transform.position - this.transform.position).normalized * attackMeleeStopRadius;

			Gizmos.color = Color.blue;
			//Gizmos.DrawLine(this.currentEnemyTarget.transform.position, gizmoRanged);
			//Gizmos.DrawSphere(gizmoRanged, 0.2f);
			Gizmos.DrawWireSphere(this.currentEnemyTarget.transform.position, /*attackRangedStopRadius*/this.agent.stoppingDistance);

			Gizmos.color = Color.magenta;
			//Gizmos.DrawLine(this.currentEnemyTarget.transform.position, gizmoSpell);
			//Gizmos.DrawSphere(gizmoSpell, 0.2f);
			Gizmos.DrawWireSphere(this.currentEnemyTarget.transform.position, /*attackSpellStopRadius*/this.agent.stoppingDistance);

			Gizmos.color = Color.red;
			//Gizmos.DrawLine(this.currentEnemyTarget.transform.position, gizmoAttack);
			//Gizmos.DrawSphere(gizmoAttack, 0.2f);
			Gizmos.DrawWireSphere(this.currentEnemyTarget.transform.position, /*attackMeleeStopRadius*/this.agent.stoppingDistance);
		}
	}

	public void StartQuestChat() {
		inQuestChat = true;
	}

	public void EndQuestChat() {
		inQuestChat = false;
	}
}

