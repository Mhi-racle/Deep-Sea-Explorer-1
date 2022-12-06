using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;

    private Camera _camera;
    //public Vector2 effectTimeBounds;
    public bool isOpen;
    public float openTime = 1.5f;

    //public Effects ownEffect;
    //public int scoreCount = 100;

    public GameObject chest;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //ownEffect = (Effects)Random.Range(0, 5);
        _camera = Camera.main;
    }

    private void Update()
    {
        if (transform.position.x <= _camera.transform.position.x - 15f) Destroy(gameObject);
    }

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;
        _animator.SetBool("isOpen", true);
        Destroy(gameObject, openTime);
        Instantiate(chest, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
    }
}
