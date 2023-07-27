using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;


    [SerializeField] private KitchenObjectsSO plateKitchenObjectSO;
    private float SpawnPlateTimer;
    private float SpawnPlateTimerMax = 4f;
    private int plateSpawnAmount;
    private int plateSpawnAmountMax = 4;

    private void Update()
    {
        SpawnPlateTimer += Time.deltaTime;
        if (SpawnPlateTimer > SpawnPlateTimerMax)
        {
            SpawnPlateTimer = 0f;
            if (plateSpawnAmount < plateSpawnAmountMax)
            {
                plateSpawnAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Player is EmptyHanded
            if(plateSpawnAmount > 0)
            {
                //There is at least one plate
                plateSpawnAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
