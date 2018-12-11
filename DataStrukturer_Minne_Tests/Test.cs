using NUnit.Framework;
using System.Collections.Generic;
using static SkalProj_Datastrukturer_Minne.Program;

namespace DataStrukturer_Minne_Tests
{
    [TestFixture()]
    public class Test
    {

        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(3, 6)]
        [TestCase(11, 22)]
        public void RecursiveEven_Test(int input, int expected)
        {
            //Arrange

            //Act
            int actual = RecursiveEven(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("[({})]")]
        [TestCase("List<int> lista = new List<int>() { 2, 3, 4 };")]
        [TestCase("no parentheses")]
        public void CheckParentheses_CorrectValues_Test(string wellFormed)
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = CheckParantheses(wellFormed);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("({)}")]
        [TestCase("[")]
        [TestCase("{})")]
        public void CheckParentheses_WrongValues_Test(string malFormed)
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = CheckParantheses(malFormed);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void RecursiveFibonacci_Test()
        {
            //Arrange

            //Act
            int actual = RecursiveFibonacci(4);

            //Assert
            Assert.Fail();
        }

        [Test()]
        public void IterativeFibonacci_Test()
        {
            //Arrange
            var expected = new List<int> { 1, 1, 2, 3, 5, 8 };

            //Act
            var actual = IterativeFibonacci(4);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
