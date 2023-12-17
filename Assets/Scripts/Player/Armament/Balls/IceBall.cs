namespace Assets.Scripts
{
    public class IceBall : Ball
    {
        public override int Attack()
        {
            gameObject.SetActive(false);

            return Damage;
        }
    }
}