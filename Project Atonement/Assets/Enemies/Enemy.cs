using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonEnemy))]
[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour {
	[SerializeField] float maxHealth = 100.0f;
	[SerializeField] float enemyHealth = 100.0f;
	[SerializeField] float attackDamage = 10f;

	[Range (0.0f, 1.0f)]
	[SerializeField] float possibleDamageLossPercentage = 0.50f;

	[SerializeField] int xpForKill = 25;
	[SerializeField] bool randomSpeed = false;
	[Range (0f, 5f)]
	[SerializeField] float agentSpeed = 1.0f;

	public EnemyUI uiSocket = null;

	private ThirdPersonEnemy thirdPersonEnemy = null;
	private UnityEngine.AI.NavMeshAgent agent = null;
	private Player player;
	private Animator animator;
	private Spawner spawner = null;
	private QuestManager questManager;
	private bool destroyTimer = false;
	private float time = 0.0f;
	private bool enemyDead = false;
	private bool hasAttackBool = false;
	private bool hasWalkBool = false;
	private bool hasDeathBool = false;
	private bool hasDieBackBool = false;
	private int wanderFrameCount = 0;
	private Vector3 wanderTarget;
	private float wanderSpeed = 0.5f;

	[SerializeField] Transform target;
	[SerializeField] float attackPlayerRadius = 5.0f;
	[SerializeField] float idleMinDistance = 10.0f;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		if (target == null) {
			if (player != null) {
				target = player.transform;
			}
		}
		this.thirdPersonEnemy = GetComponent<ThirdPersonEnemy>();
		this.agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		if (randomSpeed) {
			agent.speed = Random.Range(2.0f, 4.0f);
		} else {
			agent.speed = agentSpeed;
		}
		this.animator = GetComponent<Animator>();
		this.questManager = FindObjectOfType<QuestManager>();
		agent.updateRotation = false;
		agent.updatePosition = true;
		var animatorParams = animator.parameters;
		foreach (var param in animatorParams) {
			if (param.name == "attackBool") {
				hasAttackBool = true;
			}
			if (param.name == "walkBool") {
				hasWalkBool = true;
			}
			if (param.name == "deathBool") {
				hasDeathBool = true;
			}
			if (param.name == "dieBackBool") {
				hasDieBackBool = true;
			}
		}
		wanderTarget = new Vector3(transform.position.x + Random.Range(-5, 5), 0, transform.position.z + Random.Range(-5, 5));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player == null) {
			Start();
		}
		if (destroyTimer) {
			time += Time.deltaTime;
			if (time >= 0.7f) {
				DestroyEnemy();
			}
		} else {
			UpdateState();
		}
	}

	// set target to transform
	public void SetTarget(Transform target) {
		this.target = target;
	}

	// returns enemy health
	public float GetEnemyHealth() {
		return enemyHealth;
	}

	// returns enemy max health
	public float GetEnemyMaxHealth() {
		return maxHealth;
	}

	// returns enemy health percentage
	public float GetEnemyHealthPercentage() {
		return enemyHealth/maxHealth;
	}

	public void DealDamageToPlayer() {
		Debug.Log(attackDamage);
		var damage = Random.Range(attackDamage - (attackDamage * possibleDamageLossPercentage), attackDamage);
		Debug.Log("damage dealt to player: " + damage);
		player.DoDamageToPlayer(damage);
	}

	public void DealDamageToEnemy(float damage) {
		if (player != null && agent != null) {
			this.enemyHealth -= damage;
			if (this.enemyHealth <= 0.0f) {
				SetTarget (this.transform);
				if (agent != null) {
					agent.SetDestination (this.transform.position);
				}
				if (hasAttackBool && hasWalkBool && hasDeathBool && hasDieBackBool) {
					animator.SetBool ("attackBool", false);
					animator.SetBool ("walkBool", false);
					animator.SetBool ("deathBool", true);
					animator.SetBool ("dieBackBool", true);
				}
				if (GetComponent<QuestGiver> () != null) {
					if (agent != null && player != null) {
						print ("quest giver died");
						player.IncreaseWrath (350);
						questManager.UpdateWrathText ();
					}
				}
				this.enemyHealth = 0.0f;
				destroyTimer = true;
				this.player.IncreasePride (xpForKill);
				questManager.UpdatePrideText ();
				this.player.GetComponent<PlayerMovement> ().SetCurrentTargetToNull ();
				if (spawner != null) {
					spawner.RemoveEnemy (this);
				}
				enemyDead = true;
			}
		}
	}

	public void DestroyEnemy() {
		player.GetComponent<PlayerMovement>().SetCurrentTargetToNull();
		if (this.gameObject != null) {
			Destroy(this.gameObject);
		}
	}

	public void SetSpawner(Spawner spawner) {
		this.spawner = spawner;
	}

	public void SetAttackPlayerRadius(float radius) {
		this.attackPlayerRadius = radius;
	}

	public bool GetEnemyDead() {
		return enemyDead;
	}

	// Wander around specified area
	private void IdleWander() {
		if (wanderFrameCount < 200 && (this.transform.position - wanderTarget).magnitude > this.agent.stoppingDistance) {
			agent.SetDestination(wanderTarget);
			agent.transform.LookAt(wanderTarget);
			thirdPersonEnemy.Move(wanderTarget, false, false);
			wanderFrameCount++;
		} else {
			wanderFrameCount = 0;
			wanderTarget = new Vector3(this.transform.position.x + Random.Range(-5, 5), 0, this.transform.position.z + Random.Range(-5, 5));
		}
	}

	// target is not in attack range, but is in walking range... walk to target
	private void WalkToTarget() {
		if (agent.remainingDistance > agent.stoppingDistance) {
			if (hasAttackBool) {
				animator.SetBool("attackBool", false);
			}
			if (target != null && (this.transform.position - target.transform.position).magnitude <= attackPlayerRadius) {
				agent.SetDestination(target.position);
			}
			thirdPersonEnemy.Move(agent.desiredVelocity, false, false);
		}
	}

	private void AttackTarget() {
		agent.SetDestination(this.transform.position);
		if (hasAttackBool) {
			animator.SetBool("attackBool", true);
		}
		if (agent != null && target.transform != null) {
			agent.transform.LookAt (target.transform);
		}
		if (player != null) {
			//this.player.DoDamageToPlayer (this.attackDamage);
		}
		thirdPersonEnemy.Move(Vector3.zero, false, false);
	}

	private void UpdateState() {
		if (player != null) {
			agent.speed = agentSpeed;
			if ((this.transform.position - player.transform.position).magnitude <= this.agent.stoppingDistance) {
				AttackTarget();
			} else if ((this.transform.position - player.transform.position).magnitude >= idleMinDistance) {
				agent.speed = wanderSpeed;
				IdleWander();
			} else {
				if (hasAttackBool) {
					animator.SetBool ("attackBool", false);
				}
				if (target != null) {
					agent.SetDestination(target.transform.position);
				}
				WalkToTarget();
			}
		} else {
			agent.speed = wanderSpeed;
			IdleWander();
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, this.attackPlayerRadius);
	}
}
