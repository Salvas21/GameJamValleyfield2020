using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovManager : MonoBehaviour{
    [SerializeField] private int amount = 10;
    [SerializeField] private GameObject molotov;

    public MolotovManager(GameObject mol){
        this.molotov = mol;
    }

    public void addMolotove(int amount){
        this.amount += amount;
    }

    public void throwMol(Vector3 pos, Quaternion orientation){
        if(amount > 0){
            --amount;
            Instantiate(molotov, pos, orientation);
        }
    }

    public int getQuantity(){
        return amount;
    }
    
}
