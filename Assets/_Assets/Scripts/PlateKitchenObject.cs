using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    public event EventHandler<OnIngrediendAddedEventArgs> OnIngrediendAdded;
    public class OnIngrediendAddedEventArgs : EventArgs
    {
        public KitchenObjectsSO KitchenObjectsSO;
    }

    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectSOList;

    private List<KitchenObjectsSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList =  new List<KitchenObjectsSO>();
    }

    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Not a valid Ingredient
            return false;
        }
       

        if (kitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            //Already has this Type
            return false;
        }
        else
        {
            kitchenObjectsSOList.Add(kitchenObjectsSO);


            OnIngrediendAdded?.Invoke(this, new OnIngrediendAddedEventArgs
            {
                KitchenObjectsSO = kitchenObjectsSO
            });

            return true;
        }
        
        
    }

    public List<KitchenObjectsSO> GetKitchenObjectSOList()
    {
        return kitchenObjectsSOList;
    }



}
