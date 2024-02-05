using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    class Shoot : ICommand
    {
        private readonly Weapon weapon;
        private int shotsFired;
        private int minBulletsFired;
        private int maxBulletsFired;

        //temp variables for remembering the state of Weapon prior to firing
        private int tempCurrentMagazine;
        private int tempReserveAmmo;
        private bool tempCurrentMagState;
        private bool tempCurrentReserveState;

        private readonly static Random rand = new Random();


        public Shoot(Weapon w)
        {
            shotsFired = 0;
            this.weapon = w;
        }

        public Shoot(Weapon weapon, int minBulletsFired, int maxBulletsFired, int earlyReloadChance) : this(weapon)
        {
            this.minBulletsFired = minBulletsFired;
            this.maxBulletsFired = maxBulletsFired;
            shotsFired = rand.Next(minBulletsFired, maxBulletsFired+1);
        }

        public void Execute()
        {
            tempCurrentMagazine = weapon.currentMagazine;
            tempReserveAmmo = weapon.reserveMagazine;
            tempCurrentMagState = weapon.magazineEmpty;
            tempCurrentReserveState = weapon.reservesEmpty;

            Console.WriteLine("Bullet amount: {0}",shotsFired);
            weapon.Shoot(shotsFired);
        }

        public void Undo()
        {
            weapon.reserveMagazine += shotsFired;
        }
    }
}
