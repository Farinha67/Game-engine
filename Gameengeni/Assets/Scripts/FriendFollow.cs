using UnityEngine;
using UnityEngine.AI;

public class FriendFollow : MonoBehaviour
{
    public Transform player;
    public bool podeSeguir = false;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (podeSeguir && player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}