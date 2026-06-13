using UnityEngine;
using UnityEngine.AI;

public class FriendFollow : MonoBehaviour
{
    public Transform player;
    public Transform helicopterTarget;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void IrProHelicoptero()
    {
        if (agent != null && helicopterTarget != null)
        {
            agent.SetDestination(helicopterTarget.position);
        }
    }

    public void PararSeguir()
    {
        if (agent != null)
        {
            agent.ResetPath();
        }
    }
}