namespace Skeleton
{
    public class Hero
    {
        public Hero(IWeapon weapon, ITarget target)
        {
            Weapon = weapon;
            Target = target;
        }

        public IWeapon Weapon { get; private set; }
        public ITarget Target { get; private set; }
        public int XP { get; private set; }
        public void Attack()
        {
            Weapon.Attack(Target);
            if (Target.IsDead())
            {
                XP += Target.GiveExperience();
            }
        }
    }
}
