using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(EnemyStateMachine))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Collider2D _collider;
    private Player _target;
    private Animator _animator;
    private EnemyStateMachine _enemyStateMachine;
    private MoveState _moveState;
    private AttackState _attackState;

    private void Start()
    {
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _moveState = GetComponent<MoveState>();
        _attackState = GetComponent<AttackState>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }


    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Died;

    public void Init(Player target)
    {
        _target = target;
    }

    private IEnumerator InitEnemyDeath()
    {
        _animator.Play("Death");
        var waitForTwoSeconds = new WaitForSeconds(2f);
        yield return waitForTwoSeconds;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Died?.Invoke(this);
            _enemyStateMachine.enabled = false;
            _moveState.enabled = false;
            _attackState.enabled = false;
            _collider.enabled = false;

            StartCoroutine(InitEnemyDeath());
        }
    }
}