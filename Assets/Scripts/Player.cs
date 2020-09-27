using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private const int V = 0;
    public float Velocidad = 1;
    [SerializeField]
    public GameObject _laser;
    [SerializeField]
    public GameObject disparo;
    private float _canFire = 0.5f;
    private float _fireRate = -1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laser, disparo.transform.position, Quaternion.identity);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 

        if(transform.position.x <= 9 && transform.position.x >= -9 &&
        transform.position.y <= 6 && transform.position.y >= -4 ){
        Vector3 direccion = new Vector3( h, v, 0)  ;
        transform.Translate( direccion * Time.deltaTime * Velocidad );
        }
        else{
            transform.position = new Vector3(0,0,0);
        }
    }
}
