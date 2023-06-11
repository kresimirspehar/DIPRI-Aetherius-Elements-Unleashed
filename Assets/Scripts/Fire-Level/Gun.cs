using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
   public GameObject bullet;
   public float shootForce, upwardForce;

   public float timeBetweeShooting, spread, reloadTime, timeBetweenShots;
   public int magazineSize, bulletsPerTap;
   public bool allowButtonHold;
   
   int bulletsLeft, bulletShot;

   bool shooting, readyToShoot, realoading;

   public Camera fpsCam;
   public Transform attackPoint;

   public GameObject muzzleFlash;
   public TextMeshProUGUI ammunitionDisplay;

   public bool allowInvonke = true;

    private void Awake() {
    bulletsLeft =magazineSize;
    readyToShoot = true;
   }

   private void Update() {
    MyInput();

    if(ammunitionDisplay != null) 
      ammunitionDisplay.SetText(bulletsLeft/bulletsPerTap + "/" + magazineSize/bulletsPerTap);
   }

   private void MyInput(){
if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
else shooting = Input.GetKeyDown(KeyCode.Mouse0);

if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !realoading) Reload();

if(readyToShoot && shooting && !realoading && bulletsLeft <=0) Reload();

if(readyToShoot && shooting && !realoading && bulletsLeft > 0){
    bulletShot = 0;
    Shoot();
}
   }

   private void Shoot(){
    readyToShoot = false;

    Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    RaycastHit hit;

    Vector3 targetPoint;
    if(Physics.Raycast(ray, out hit))
       targetPoint = hit.point;
    else 
       targetPoint = ray.GetPoint(75);

    Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

    float x = Random.Range(-spread, spread);
    float y = Random.Range(-spread, spread);

    Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x,y,0);

    GameObject currentBullet = Instantiate( bullet, attackPoint.position, Quaternion.identity);

    currentBullet.transform.forward = directionWithSpread.normalized;

    currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
    currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

if(muzzleFlash != null)
   Instantiate(muzzleFlash,attackPoint.position, Quaternion.identity);

    bulletsLeft--;
    bulletShot++;

    if(allowInvonke){
        Invoke("ResetShot", timeBetweeShooting);
        allowInvonke = false;
    }

    if(bulletShot < bulletsPerTap && bulletsLeft > 0)
      Invoke("Shoot", timeBetweenShots);
   }

   private void ResetShot(){
    readyToShoot = true;
    allowInvonke = true;
   }

     private void Reload(){
    realoading = true;
    Invoke("ReloadFinished", reloadTime);
   }

     private void ReloadFinished(){
    bulletsLeft = magazineSize;
    realoading = false;
   }
}
