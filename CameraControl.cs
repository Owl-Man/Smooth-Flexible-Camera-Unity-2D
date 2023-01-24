using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float dumping = 1.5f;
    [SerializeField] private Vector2 offset = new Vector2(2f, 1f);

    [SerializeField] private bool hasLimit = false;
    [SerializeField] private float leftLimit, rightLimit, bottomLimit, upperLimit;

    private Vector3 _target;
    private int _lastX, _currentX;
    private bool _isLeft;

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FocusOnPlayer(_isLeft);
    }

    private void Update()
    {
        _currentX = Mathf.RoundToInt(_player.position.x);

        if (_currentX > _lastX) _isLeft = false;
        else if (_currentX < _lastX) _isLeft = true;

        _lastX = Mathf.RoundToInt(_player.position.x);

        _target = _isLeft
            ? new Vector3(_player.position.x - offset.x, _player.position.y + offset.y, transform.position.z)
            : new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);

        Vector3 currentPosition = Vector3.Lerp(transform.position, _target, dumping * Time.deltaTime);

        transform.position = currentPosition;

        if (hasLimit) 
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit * -1, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit * -1, upperLimit),
                transform.position.z
            );
        }
    }

    public void FocusOnPlayer(bool playerIsLeft)
    {
        _lastX = Mathf.RoundToInt(_player.position.x);

        transform.position = playerIsLeft
            ? new Vector3(_player.position.x - offset.x, _player.position.y - offset.y, transform.position.z)
            : new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);
    }
}
