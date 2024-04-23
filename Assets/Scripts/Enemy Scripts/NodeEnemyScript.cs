using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy2AI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public Transform player;
    public float stoppingDistance = 0.1f, walkSpeed, catchDistance, jumpscareTime;
    public int nodeNum = 0, delay = 3;
    bool walking = true;
    public string deathScene;

    void Start()
    {
        SetDestination();
    }

    void Update()
    {
        if (walking)
        {

            if (ai.remainingDistance <= stoppingDistance)
            {
                StartCoroutine(IdleAfterDelay(delay)); // Start idle coroutine after reaching destination
            }
            else
            {
                ai.destination = destinations[nodeNum].position;
                ai.speed = walkSpeed;
                aiAnim.ResetTrigger("idle");
                aiAnim.SetTrigger("walk");
            }
        }
        float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("idle");
                aiAnim.SetTrigger("jumpscare");
                player.gameObject.SetActive(false);
                StartCoroutine(DeathRoutine());
            }
    }

    void SetDestination()
    {
        if (nodeNum < destinations.Count)
        {
            ai.destination = destinations[nodeNum].position;
        }
        else
        {
            Debug.LogWarning("No more destinations!");
            nodeNum = 0;
        }
    }
    IEnumerator IdleAfterDelay(float del)
    {
        walking = false;
        aiAnim.ResetTrigger("walk");
        aiAnim.SetTrigger("idle");
        ai.speed = 0;

        yield return new WaitForSeconds(del);

        nodeNum++;
        SetDestination();
        walking = true;
    }
    IEnumerator DeathRoutine()
    {
        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("jumpscare");

        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
    
}

