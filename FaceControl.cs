using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4t12
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FaceControl : Attribute
    {
        public int minAge;
        public int maxAge;
        public int money;
        public bool isTechnoCool;
        public int maxCount = 100;
        public bool NightClubCheck(List<Human> Club, Human human)
        {
            if (minAge <= human.age && human.age < maxAge && money <= human.money && human.isTechnoCool == isTechnoCool && Club.Count < maxCount)
                return true;
            else
                return false;
        }
        public bool DanceClubCheck(List<Human> Club, Human human)
        {
            if (minAge <= human.age && human.isTechnoCool == isTechnoCool && Club.Count < maxCount)
                return true;
            else
                return false;
        }
        public bool KinderClubCheck(List<Human> Club, Human human)
        {
            if (human.age < maxAge && Club.Count < maxCount)
                return true;
            else
                return false;
        }
    }
}
