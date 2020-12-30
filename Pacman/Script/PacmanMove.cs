using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidbody2;
    private SelfAnim animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent < Rigidbody2D>();
        animator = GetComponent<SelfAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMgr.Instance.isStartGame)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector2 dest = rigidbody2.position + Vector2.up * moveSpeed / 10;
                rigidbody2.MovePosition(dest);
                animator.ChangeDir(SelfAnim.MoveDirAnim.Up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector2 dest = rigidbody2.position + Vector2.down * moveSpeed / 10;
                rigidbody2.MovePosition(dest);
                animator.ChangeDir(SelfAnim.MoveDirAnim.Down);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector2 dest = rigidbody2.position + Vector2.left * moveSpeed / 10;
                rigidbody2.MovePosition(dest);
                animator.ChangeDir(SelfAnim.MoveDirAnim.Left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector2 dest = rigidbody2.position + Vector2.right * moveSpeed / 10;
                rigidbody2.MovePosition(dest);
                animator.ChangeDir(SelfAnim.MoveDirAnim.Right);
            }
        }
    }
}
