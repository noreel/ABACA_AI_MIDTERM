using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class chase : MonoBehaviour
{
    GameObject target;
    public NavMeshAgent enemy;

    public ThirdPersonCharacter character;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        enemy.updateRotation = false;
    }

    void Update()
    {
        if (target != null)
        {
            enemy.SetDestination(target.transform.position);
        }
        else
        {
            Debug.Log("Gotcha beach");
        }

        if (enemy.remainingDistance > enemy.stoppingDistance)
        {
            character.Move(enemy.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with target. Destroying follower.");
            Destroy(collision.gameObject);

            
        }     

    }
}
