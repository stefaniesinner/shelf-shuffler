using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    [SerializeField]
    private LayerMask interactionLayer; // layer object to interact with
    [SerializeField]
    private GameObject interactionObject; // object to interact with
    [SerializeField]
    private Transform interactionPoint;

    private const float InteractionRange = 0.2f;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {

    }

    public GameObject InteractionObject
    {
        get { return interactionObject; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
