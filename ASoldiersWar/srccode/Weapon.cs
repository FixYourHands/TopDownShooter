using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1.WarriorFight
{
    public abstract class Weapon
    {
        public int MAX_MAGAZINE_SIZE { get; set; }
        public string Name { get; set; }
        public int currentMagazine { get; set; }
        public int reserveMagazine { get; set; }
        public bool magazineEmpty { get; set; }
        public bool reservesEmpty { get; set; }
        public double weaponDamage { get; set; }

        protected virtual void Reload()
        {
            if (reservesEmpty)
            {
                Console.WriteLine("Cant Reload!");
                return;
            }

            while(TryReload());
            Console.WriteLine("Bullet amount: {0}/{1}", currentMagazine, reserveMagazine);
        }
        private bool TryReload()
        {
            if (reservesEmpty)
            {
                return false; //out of ammo
            }

            if (currentMagazine < MAX_MAGAZINE_SIZE)
            {
                currentMagazine++;
                reserveMagazine--;
                if (reserveMagazine <= 0)
                {
                    reservesEmpty = true;
                }
                return true; 
            }
            return false;

        }

        
        public virtual void Shoot(int numOfRounds)
        {
            for (int i = 0; i < numOfRounds; i++)
            {
                if (TryShoot())
                {
                    // Handle successful shot (e.g., play sound, apply effects)
                }
                else
                {
                    // Handle empty gun (e.g., play empty sound, notify player)
                    return; // Stop shooting if out of ammo
                }
            }
        }

        private bool TryShoot()
        {

            //check if magazine is empty
            if (currentMagazine > 0)
            {
                currentMagazine--;
                return true;
            }

            //reload if reserves arent empty
            if (!reservesEmpty)
            {
                Reload();
                return TryShoot(); // Recursive call to try again after reloading
            }

            magazineEmpty = true;
            reservesEmpty = true;
            return false;
        }
    }
}
