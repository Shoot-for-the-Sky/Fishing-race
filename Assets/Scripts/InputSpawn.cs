using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class InputSpawn : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;

    void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }

    protected virtual GameObject spawnObject()
    {

        Debug.Log("Spawning object");
        // 

        Vector3 positionOfSpawnedObject = transform.position;
        Quaternion rotationOfSpawnedObject = Quaternion.Euler(30,0,0);
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    private void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            spawnObject();
        }

    }
}