using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    public GameObject bullet;
    public GameObject goldBullet;
    public int totalAmmo = 10;
    public int totalGoldBullets = 10;
    private bool armed = false;
    private bool goldArmed = false;

    private bool goldEquip = false;

    public Weapon(GameObject bullet, GameObject goldenBullet){
        this.bullet = bullet;
        if(goldBullet == null){
            this.goldBullet = bullet;
        }
    }

    public void shoot(Vector3 pos, Quaternion rotation){
        if(goldEquip && goldArmed){
            goldArmed = !goldArmed;
            Instantiate(goldBullet, pos, rotation);
            return;
        }else if(!goldEquip && armed){
            armed = !armed;
            Instantiate(bullet, pos, rotation);
            return;
        }
    }

    public void addAmmo(bool gold, int ammo){
        if(gold){
            totalGoldBullets += ammo;
            return;
        }
        this.totalAmmo += ammo;
    }
    public void armeWeapon(){
        if(goldEquip && !goldArmed && totalGoldBullets > 0){
            totalGoldBullets--;
            goldArmed = true;
            return;
        }
        if(!goldArmed && !armed && totalAmmo > 0){
            totalAmmo--;
            armed = true;
        }
    }

    public void goGold(){
        goldEquip = true;
    }

    public void goNormal(){
        goldEquip = false;
    }

    public void switchWeaponState(){
        goldArmed = !goldArmed;
    }
}

