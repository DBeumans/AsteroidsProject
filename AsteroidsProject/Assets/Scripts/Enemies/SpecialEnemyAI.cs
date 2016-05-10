using UnityEngine;
using System.Collections;

public class SpecialEnemyAI : MonoBehaviour {

    private Transform GoAfter;
    private float speed;
    private Vector3 dir;
    private float rot;



    [SerializeField]
    GameObject _camtar; // Camera Target

    PlayerMovement _player;
    PlayerShooting _playerShooting;

    SpecialEnemyAI _enemy;

    float f_RotSpeed = 3.0f, f_MoveSpeed = 3.0f;

    public bool Controlable = false;

    // Use this for initialization
    void Start()
    {
        _camtar.SetActive(false);
        _player = GetComponent<PlayerMovement>();
        _player.enabled = false;

        _playerShooting = GetComponent<PlayerShooting>();
        _playerShooting.enabled = false;

        _enemy = GetComponent<SpecialEnemyAI>();
        _enemy.enabled = true;

        speed = Random.Range(1f, 5f);

        //GoAfter = GameObject.Find("GoAfterMe").GetComponent<Transform>();
        GoAfter = GameObject.Find("Player").GetComponent<Transform>();
        dir = GoAfter.position - transform.position;
        rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
    }

    // Update is called once per frame
    void Update()
    {


        if (Controlable)
        {
            _player.enabled = true;
            _playerShooting.enabled = true;
            _enemy.enabled = false;
            gameObject.tag = "Player";
            gameObject.name = "Player";
            gameObject.layer = LayerMask.NameToLayer("Player");
            _camtar.SetActive(true);
        }


    }

    void FixedUpdate()
    {
        GoAfter = GameObject.Find("Player").GetComponent<Transform>();
        transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        transform.position = Vector3.MoveTowards(transform.position, GoAfter.position, Time.deltaTime * speed);

    }
}
