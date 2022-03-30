using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class ReachTarget : Agent
{
    public float speed;
    [SerializeField] private Transform getTarget;
    [SerializeField] private Transform dropTarget;

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> actions = actionsOut.ContinuousActions;
        actions[0] = Input.GetAxisRaw("Horizontal");
        actions[1] = Input.GetAxisRaw("Vertical");
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(-0.955f, 0.189f, 0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // agent and target positions
        sensor.AddObservation(transform.position);
        sensor.AddObservation(getTarget.position);
        sensor.AddObservation(dropTarget.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float xMove = actions.ContinuousActions[0];
        float yMove = actions.ContinuousActions[1];

        transform.position += new Vector3(xMove, yMove, 0) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SetReward(1f);
        EndEpisode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetReward(-1f);
        EndEpisode();
    }
}
