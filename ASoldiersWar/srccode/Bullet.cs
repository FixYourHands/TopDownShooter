using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class Bullet
    {
        public string Name { get;}
        private readonly float Damage;

        public Bullet(string name, float damage)
        {
            this.Name = name;
            this.Damage = damage;
        }

        public float GetDamage()
        {
            return this.Damage;
        }

        public static Bullet UseAK47Rounds()
        {
            return new Bullet("7.62 x 39mm", 33.0f);
        }

        public static Bullet UseM240BRounds()
        {
            return new Bullet("7.62 x 51mm NATO", 33.0f);
        }
    }
}
