using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Ball : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Camera camera;
    
    private void Update() {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePosition - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.DrawLine(transform.position, mousePosition, Color.red);
        if (!Input.GetMouseButtonDown(0)) {
            return;
        }

        var g = Mathf.Abs(Physics2D.gravity.y);

        var H = mousePosition.y - transform.position.y - transform.localScale.y * 0.5f;

        var v0 = (Mathf.Sqrt(2f * g * H)) / Mathf.Sin(angle * Mathf.Deg2Rad);

        var v0x = v0 * Mathf.Cos(angle * Mathf.Deg2Rad);
        var v0y = v0 * Mathf.Sin(angle * Mathf.Deg2Rad);

        var velocity = new Vector2(v0x, v0y);
        rigidbody2D.velocity = velocity;
    }
}