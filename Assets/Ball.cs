using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private Camera camera;
    [SerializeField] private float jumpPower=1f;
    [SerializeField] private float duration=2f;
    private Vector3 startPosition;
    private bool jumping;

    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !jumping) {
            jumping = true;
            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            transform.DOJump(mousePosition, jumpPower, 1, duration).OnComplete(jumpComplete);
        }
    }

    private void jumpComplete() {
        transform.position = startPosition;
        jumping = false;
    }
}