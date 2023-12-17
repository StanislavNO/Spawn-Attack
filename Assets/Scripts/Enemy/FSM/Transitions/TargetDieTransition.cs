namespace Assets.Scripts
{
    public class TargetDieTransition : Transition
    {
        private Health _targetHealth;
        private int _minLifePoint = 0;

        private void Start()
        {
            _targetHealth = Target.GetComponent<Health>();
        }

        private void Update()
        {
            if (_targetHealth.LivePoint <= _minLifePoint)
                NeedTransit = true;
        }
    }
}