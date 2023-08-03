using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;


    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        plateKitchenObject.OnIngrediendAdded += PlateKitchenObject_OnIngrediendAdded;
    }

    private void PlateKitchenObject_OnIngrediendAdded(object sender, PlateKitchenObject.OnIngrediendAddedEventArgs e)
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        foreach (Transform child in transform) 
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(KitchenObjectsSO kitchenObjectsSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconsSingleUI>().SetKitchenObjectSO(kitchenObjectsSO);
        }
    }
}
