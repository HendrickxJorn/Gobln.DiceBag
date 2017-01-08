using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gobln.DiceBag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace Gobln.DiceBag.Tests
{
    [TestClass()]
    public class DiceTests
    {
        [TestMethod]
        public void TestDiceRoll()
        {

            var dice2D6 = new Dice(DiceTypes.d6, 2);

            var re = dice2D6.Roll();

            if (re == dice2D6.Result)
            {

            }

            var dede = dice2D6.Avarage;

            dede = dede;
        }

        [TestMethod]
        public void TestDiceCupRoll()
        {
            var cb = new DicesCup();
            cb.Add(new Dice(DiceTypes.d6, 2));
            cb.Add(new Dice(DiceTypes.d6));
            cb.Add(new Dice(DiceTypes.d6));
            cb.Add(new Dice(DiceTypes.d6));
            cb.Add(new Dice(DiceTypes.d6));
            cb.Add(new Dice(DiceTypes.d6));
            cb.Add(new Dice(10000));

            var re = cb.Roll();

            if (re == cb.Result)
            {

            }

            for (int i = 0; i < 50; i++)
            {
                Debug.WriteLine(new Dice(DiceTypes.d10).Roll());
            }

            if (re == cb.Result)
            {

            }
        }
    }
}
