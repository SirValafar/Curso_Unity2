using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private const int V = 0;
    public float Velocidad = 1;
    public float _speedMultiplicador = 2;
    [SerializeField]
    public GameObject _laser;
    [SerializeField]
    public GameObject _laserTriple;

    [SerializeField]
    public GameObject disparo;

    private float _canFire = 0.5f;
    private float _fireRate = -1f;

    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;
    [SerializeField]

    private bool _tripleShotActive = false;
    private bool _SpeedActive = false;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.Log("The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Calcular();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
           FireLaser();
        }
    }

    void Calcular(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 

        if(transform.position.x <= 9 && transform.position.x >= -9 &&
        transform.position.y <= 6 && transform.position.y >= -4 ){
        Vector3 direccion = new Vector3( h, v, 0);
        transform.Translate( direccion * Time.deltaTime * Velocidad );
        }
        else{
            transform.position = new Vector3(0,0,0);
        }
    }

    public void Damage(){
        _lives--;
            if (_lives < 1)
            {
                Destroy(this.gameObject);
            }
    }

    void FireLaser(){
        _canFire = Time.deltaTime + _fireRate;
        if (_tripleShotActive == true)
        {
        Instantiate(_laserTriple, transform.position + new Vector3(0, 1.05f,0), Quaternion.identity);
        }
        else{
        Instantiate(_laser, transform.position + new Vector3(0, 1.05f,0), Quaternion.identity);
        }
    
    }

    public void TripleShotActive(){
        _tripleShotActive = true;
        StartCoroutine(TripleShotPower());
    }

    IEnumerator TripleShotPower(){
        yield return new WaitForSeconds(5.0f);
        _tripleShotActive = false;
    }
    public void SpeedActive(){
        Velocidad *= _speedMultiplicador;
        _SpeedActive = true;
        StartCoroutine(SpeedPower());
    }

    IEnumerator SpeedPower(){
        yield return new WaitForSeconds(5.0f);
        _SpeedActive = false;
        Velocidad /= _speedMultiplicador;
    }

}
