using UnityEngine;

namespace Survival.Player
{
    public class Player : MonoBehaviour
    {
        private Vector3 leftBottom;
        private Vector3 rightTop;

        private void Awake()
        {
            leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 7));
            rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 7));
        }

        private void OnDrawGizmos()
        {
            Vector3 leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 7));
            Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelHeight, 7));
            Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 7));
            Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, 7));
            Debug.DrawLine(leftBottom, leftTop, Color.red);
            Debug.DrawLine(leftTop, rightTop, Color.red);
            Debug.DrawLine(rightTop, rightBottom, Color.red);
            Debug.DrawLine(rightBottom, leftBottom, Color.red);
        }

        public void SetPosition(Vector3 pos, int speed)
        {
            transform.position += pos * speed;

            var x = Mathf.Clamp(transform.position.x, leftBottom.x, rightTop.x);
            var z = Mathf.Clamp(transform.position.z, leftBottom.z, rightTop.z);

            transform.position = new Vector3(x, transform.position.y, z);
        }

        public void SetRotation()
        {
            var lookAtPos = Input.mousePosition;
            lookAtPos.z = Camera.main.transform.position.y - transform.position.y;
            lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
            transform.forward = lookAtPos - transform.position;
        }
    }
}
