using System.Collections;
using UnityEngine;

namespace VIEN_Assignment.Scripts
{
    public class DrawerAnimation : MonoBehaviour, IRaycastInteractable
    {
        [SerializeField] private Vector3 targetOffset;
        [SerializeField] private float animationDuration = 0.5f;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;
        private bool _isOpen;
        private bool _isMoving;

        private void Start()
        {
            _initialPosition = transform.localPosition;
            _targetPosition = _initialPosition + targetOffset;
        }

        private IEnumerator MoveDrawer(Vector3 startPos, Vector3 endPos)
        {
            var elapsed = 0f;
            _isMoving = true;
            while (elapsed < animationDuration)
            {
                transform.localPosition = Vector3.Lerp(startPos, endPos, elapsed / animationDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = endPos;
            _isMoving = false;
        }

        private IEnumerator OpenAnimation()
        {
            if (_isMoving) yield break;
            var startPos = transform.localPosition;
            var endPos = _isOpen ? _initialPosition : _targetPosition;
            _isOpen = !_isOpen;
            yield return StartCoroutine(MoveDrawer(startPos, endPos));
        }
        public void OnRaycastHit()
        {
            if (!_isMoving)
                StartCoroutine(OpenAnimation());
        }
    }
}