using UnityEngine;

public class BedEventSender : MonoBehaviour
{
    public delegate void ApproachEvent();
    public event ApproachEvent OnApproachBed;


    public float minimumDistance;
    private Transform _player;
    private bool _approached;


    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) <= minimumDistance && !_approached)
        {
            OnApproachBed?.Invoke();
            _approached = true;
        }
    }
}
