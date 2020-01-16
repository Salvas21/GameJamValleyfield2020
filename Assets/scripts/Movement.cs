using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] public const int maxHealth = 3;
    [SerializeField] private GameObject molotov;
    private int hp = maxHealth;
    private Weapon gun;
    private Weapon molotovs;
    [SerializeField] private float movementSpeed = 0.4f;
    private Camera cameraPlayer;
    private GameObject character;
    private float mousePositionX;
    private float mousePositionY;
    public GameObject bullet;
    private Rigidbody2D rb;
    public GameObject cannonPosition;
    private Animator animator;
    [SerializeField] private string deathSceneName;
    private float orientationCorrection = 90f;
    private MolotovManager molotovManager;


    void Start()
    {
        character = this.gameObject.transform.GetChild(0).gameObject;
        gun = new Weapon(bullet, null);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        rb.angularDrag = 0;
        rb.mass = 0.000001f;
        cameraPlayer = GameObject.FindObjectOfType<Camera>();
        if (deathSceneName == null || deathSceneName == "")
        {
            Debug.LogError("DeathScene not set!!");
        }
        molotovManager = new MolotovManager(molotov);
        animator = GetComponentInChildren<Animator>();
        animator.speed = 8;
    }

    void Update(){
        handleInput();
        updateRotation();
        if (hp <= 0){
            SceneManager.LoadScene(deathSceneName, LoadSceneMode.Single);
        }
    }

    private void updateRotation()
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPlayer.nearClipPlane));
        float a = targetPos.x - gameObject.transform.position.x;
        float b = targetPos.y - gameObject.transform.position.y;
        float r = b / a;
        float zRotation = Mathf.Atan(r);
        if (a > 0 && b < 0)
        {
            zRotation += (360 * Mathf.Deg2Rad);
        }
        else if (a < 0)
        {
            zRotation += (180 * Mathf.Deg2Rad);
        }
        zRotation *= Mathf.Rad2Deg;
        character.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }

    void handleInput()
    {
        handleMoveCtrls();
        handleOffensiveCtrks();
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Ennemi"){
            takeDamage();
        }
        else if (other.gameObject.tag == "Molotov")
        {
            molotovManager.addMolotove(1);
        }
        else if (other.gameObject.tag == "Bullet")
        {
            gun.addAmmo(false, 1);
        }
        else if (other.gameObject.tag == "GoldBullet")
        {
            gun.addAmmo(true, 1);
        }
    }

    private void loadWeappon()
    {
        gun.armeWeapon();
    }

    private void shoot()
    {
        if (cannonPosition == null)
        {
            gun.shoot(transform.position, character.transform.rotation);
        }
        else
        {
            gun.shoot(cannonPosition.transform.position, character.transform.rotation);
        }
    }
    public void takeDamage()
    {
        hp--;
    }

    private void handleMoveCtrls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(movementSpeed, 0f, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(movementSpeed * -1, 0f, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0f, movementSpeed, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0f, movementSpeed * -1, 0f) * Time.deltaTime);
        }
        animator.SetBool("IsMoving", (rb.velocity != Vector2.zero));
        rb.velocity = Vector3.zero;
    }

    private void handleOffensiveCtrks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            loadWeappon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.goNormal();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.goGold();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            molotovManager.throwMol(transform.position, character.transform.rotation);
        }
    }

    public int getHealth(){
        return hp;
    }
    public int getMaxHealth(){
        return maxHealth;
    }
    public Weapon getWeapon(){
        return gun;
    }
}
