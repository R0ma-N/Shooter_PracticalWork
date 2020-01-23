
namespace Shooter
{
    public class Firearms : WeaponBase
    {
        public override void Fire()
        {
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                BulletsCount--;
            }    
        }

        public override void StopFire()
        {
        }
    }
}
