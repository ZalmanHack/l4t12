using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace l4t12
{
    /*
     * Внутри класса NightWorld создайте 3 публичных статических свойства, который бы являлись
     * списками экземпляров класса Human:
     *      1) NightClub - в коллекции могут находиться только экземпляры класса Human старше 18 (включительно)
     *      и моложе 50 (не включительно) лет, как минимум с 300$ (включительно) в кармане и любящих техно-музыку.
     *      2) DanceClub - в коллекции могут находиться только экземпляры класса Human старше 55 (включительно)
     *      лет и которые любят техно-музыку.
     *      3) KinderClub - в коллекции могут находиться только экземпляры класса до 18 (не включительно) лет.
     *      4) Каждый клуб должен иметь максимальную вместимость - maxCount, равную 100 (включительно).
     * Создайте в отдельном файле атрибут FaceControl, который бы являлся валидационным атрибутом 
     * и определял возможность доступа экземпляров класса Human в тот или иной клуб и при этом покрывал
     * все необходимые условия и ограничения по работе клубов. Атрибут не должен иметь никаких конструкторов, кроме 
     * конструктора по умолчанию. Область применения атрибута определите самостоятельно.      
     * Для каждого из клубов внутри класса NightWorld реализуйте публичный статический метод FaceControl(), который должен:
     *      1) Ничего не возвращать.
     *      2) Принимать переменную клуба и экземпляр класса Human.
     *      3) В случае если экземпляр класса Human подходит под текущие ограничения клуба и клуб не заполнен до предела, то
     *         метод должен пропускать его в клуб - добавив его в соответствующую переменную.
     *         
     * Логику работы своей программы можно проверить в методе Main(), он не будет участвовать в проверке.
     * Шаблон класса Human изменять нельзя.
     */

    public class NightWorld
    {
        [FaceControl(minAge = 18, maxAge = 50, money = 300, isTechnoCool = true)]
        public static List<Human> NightClub { get; set; } = new List<Human>();
        [FaceControl(minAge = 55, isTechnoCool = true)]
        public static List<Human> DanceClub { get; set; } = new List<Human>();
        [FaceControl(maxAge = 18)]
        public static List<Human> KinderClub { get; set; } = new List<Human>();

        public static List<Human> Club { get; set; } = new List<Human>();

        public static void Main(string[] args)
        {
            Human p1 = new Human() { age = 18, money = 300, isTechnoCool = true };
            Human p2 = new Human() { age = 56, money = 300, isTechnoCool = true };
            Human p3 = new Human() { age = 12, money = 300, isTechnoCool = true };

            FaceControl(NightClub, p1);
            FaceControl(DanceClub, p2);
            FaceControl(KinderClub, p3);
            FaceControl(KinderClub, p3);
            FaceControl(KinderClub, p3);
            FaceControl(Club, p3);

            Console.WriteLine(NightClub.Count);
            Console.WriteLine(DanceClub.Count);
            Console.WriteLine(KinderClub.Count);
            Console.WriteLine(Club.Count);
        }

        public static void FaceControl(List<Human> Club, Human human)
        {
            if (Club.Equals(NightClub))
            {
                if (typeof(NightWorld).GetProperty("NightClub").GetCustomAttribute<FaceControl>().NightClubCheck(Club, human))
                    NightClub.Add(human);
            }   
            else if (Club.Equals(DanceClub))
            {
                if (typeof(NightWorld).GetProperty("DanceClub").GetCustomAttribute<FaceControl>().DanceClubCheck(Club, human))
                    DanceClub.Add(human);
            }
            else if (Club.Equals(KinderClub))
            {
                if (typeof(NightWorld).GetProperty("KinderClub").GetCustomAttribute<FaceControl>().KinderClubCheck(Club, human))
                    KinderClub.Add(human);
            }
            else
            {
                Club.Add(human);
            }
                
        }
    }
}
