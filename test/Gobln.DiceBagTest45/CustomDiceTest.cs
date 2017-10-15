using Gobln.DiceBag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Gobln.DiceBagTest45
{
    [TestClass()]
    public class CustomDice45Test
    {
        [TestMethod]
        public void Net45TestCustomDiceRoll()
        {

            var diceCustom = new CustomDice(new[] { "Eagel", "Snake", "Bear", "Wolf", "Fox", "Cat" });

            var re = diceCustom.Roll();

            if (re == diceCustom.Result)
            {

            }
        }

        [TestMethod]
        public void Net45TestCustomDiceCupRoll()
        {
            var cb = new CustomDicesCup();
            cb.Add(new CustomDice(new[] { "Eagel", "Snake", "Bear", "Wolf", "Fox", "Cat" }));
            cb.Add(new CustomDice(new[] { "Human", "Mammel", "Insect" }));
            cb.Add(new CustomDice(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }));
            cb.Add(new CustomDice(new[] { "Eagel", "Snake", "Bear", "Wolf", "Fox", "Cat" }));

            var re = cb.Roll();

            if (re == cb.Result)
            {

            }

            for (int i = 0; i < 50; i++)
            {
                Debug.WriteLine(new CustomDice(new[] { "Eagel", "Snake", "Bear", "Wolf", "Fox", "Cat" }).Roll());
            }

            if (re == cb.Result)
            {

            }
        }
    }
}
