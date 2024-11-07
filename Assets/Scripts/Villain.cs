using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : HowToMove
{
    public static string PLAYER_TAG = "Player";

    private Transform characterTarget;
    private Vector3 previousPosition;

    private Vector3 initialLocation;

    private Vector3 villainTraversal;

    private bool damageMade;

    [SerializeField]
    private float pauseDamage = 1f;
    private float pauseCountDown;

    [SerializeField] private float damageAmount = 12f;

    [SerializeField] private float speed = 0.8f;

    private float timeFollow;
    private float pauseTurning = 1f;

    [SerializeField] private float pauseTurningCountDown = 1f;

    private Vector3 myScale;

    private HealthStatus villainHealth;

    private VillainGroups villainGroup;

    protected override void Awake() {
        base.Awake();
    }

    private void Start() {

        characterTarget = GameObject.FindWithTag(PLAYER_TAG).transform;
        previousPosition = characterTarget.position;

        initialLocation = transform.position;

        timeFollow = Time.time;
        pauseTurning = ((float)1f - (float)xSpeed);
        pauseTurning += 1f * pauseTurningCountDown;

        villainHealth = GetComponent<HealthStatus>();

        villainGroup = GetComponentInParent<VillainGroups>();
    }

    private void OnDisable() {
        if (!villainHealth.IsAlive())
            villainGroup.RemoveVillain(this);
    }

    private void Update() {

        if (!characterTarget) { //if player dead
            return;
        }

        if (!villainHealth.IsAlive()) {  //if villain dead
            return;
        }

        WhereToFace();
    }

    private void FixedUpdate() {

        if (!villainHealth.IsAlive()) { //if villain dead
            return;
        }

        startTheChase();
    }

    void startTheChase() {
        if (HasPlayerTarget) {

            if (!damageMade) {
                ChaseCharacter();
            }
            else {

                if (Time.time < pauseCountDown) {
                    villainTraversal = initialLocation - transform.position;
                }
                
                else {
                    damageMade = false;
                }
            }
        }
        else {

            villainTraversal = initialLocation - transform.position;

            if (Vector3.Distance(transform.position, initialLocation) < 0.1f) {
                villainTraversal = Vector3.zero;
            }
        }
        HandleMovement(villainTraversal.x, villainTraversal.y);
    }

    void ChaseCharacter() {

        if (Time.time - timeFollow > pauseTurning) {
            previousPosition = characterTarget.position;
            timeFollow = Time.time;
        }

        if (Vector3.Distance(transform.position, previousPosition) > 0.016f) {
            villainTraversal = (previousPosition - transform.position).normalized * speed;
        }
        
        else {
            villainTraversal = Vector3.zero;
        }
    }

    void WhereToFace() {

        myScale = transform.localScale;

        if (HasPlayerTarget) {

            if (characterTarget.position.x > transform.position.x) {
                myScale.x = Mathf.Abs(myScale.x);
            }
            else if(characterTarget.position.x < transform.position.x) {
                myScale.x = -Mathf.Abs(myScale.x);
            }
        }
        
        else {

            if (initialLocation.x > transform.position.x) {
                myScale.x = Mathf.Abs(myScale.x);
            }

            else if (initialLocation.x < transform.position.x) {
                myScale.x = -Mathf.Abs(myScale.x);
            }
        }

        transform.localScale = myScale;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag(PLAYER_TAG)) {
            pauseCountDown = Time.time + pauseDamage;

            damageMade = true;
            collision.GetComponent<HealthStatus>().TakeDamage(damageAmount);
        }
    }
}


