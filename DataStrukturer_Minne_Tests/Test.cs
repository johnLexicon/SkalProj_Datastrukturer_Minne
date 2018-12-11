using NUnit.Framework;
using System;
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
    }
}
