using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabObject;

    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Player is not carrying anything
            KitchenObject.SpawnKitchenObject(kitchenObjectsSO, player);
            
            OnPlayerGrabObject?.Invoke(this, EventArgs.Empty);
        }
       
    }
  
}
