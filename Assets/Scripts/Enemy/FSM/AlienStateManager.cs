using Assets.Scripts.Enemy.FSM;
using UnityEngine;

public class AlienStateManager : MonoBehaviour
{
    Alien alien;
    Transform player;
    AlienStateMachine alienStateMachine;

    [SerializeField] float sightDistance = 10.0f;
    [SerializeField] float attackDistance = 3.0f;

    public void Initialize(Alien alien)
    {
        this.alien = alien;

        alienStateMachine = new AlienStateMachine();
        alienStateMachine.Initialize(new IdleState(alien));
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (alien != null)
        {
            alienStateMachine.Update();
            HandleStates();
        }
    }

    private void HandleStates()
    {
        float sqrDistance = CalculateSqrDistance(player, alien.transform);

        if (sqrDistance < sightDistance * sightDistance)
            alienStateMachine.TransitionTo(new ChaseState(alien));

        if (sqrDistance < attackDistance * attackDistance)
            alienStateMachine.TransitionTo(new AttackState(alien));
    }

    public float CalculateSqrDistance(Transform obj1, Transform obj2)
    {
        Vector3 distance = obj1.position - obj2.position;
        return distance.sqrMagnitude;
    }
}
