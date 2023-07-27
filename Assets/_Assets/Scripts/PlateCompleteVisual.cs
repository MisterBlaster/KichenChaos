using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public struct KitchenObjectSo_GameObject
    {
        public KitchenObjectsSO kitchenObjectsSO;
        public GameObject gameObject;

    }


    [SerializeField] private PlateKitchenObject plateKitchenObject;

    [SerializeField] private List<KitchenObjectSo_GameObject> kitchenObjectSOGameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngrediendAdded += PlateKitchenObject_OnIngrediendAdded;

        foreach (KitchenObjectSo_GameObject kitchenObjectSOGameObject in kitchenObjectSOGameObjectList)
        {
                kitchenObjectSOGameObject.gameObject.SetActive(false);   

        }
    }

    private void PlateKitchenObject_OnIngrediendAdded(object sender, PlateKitchenObject.OnIngrediendAddedEventArgs e)
    {
        foreach (KitchenObjectSo_GameObject kitchenObjectSOGameObject  in kitchenObjectSOGameObjectList)
        {
            if (kitchenObjectSOGameObject.kitchenObjectsSO == e.KitchenObjectsSO)
            {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
     
    }
}
