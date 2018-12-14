using NUnit.Framework;
using System.Collections.Generic;
using static SkalProj_Datastrukturer_Minne.Program;
using SkalProj_Datastrukturer_Minne;
using System.Text;
using System.IO;
using System;

namespace DataStrukturer_Minne_Tests
{
    [TestFixture()]
    public class Test
    {

        [TestCase(0, 0)]
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

        [TestCase(0, 0)]
        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(3, 6)]
        [TestCase(11, 22)]
        public void IterativeEven_Test(int input, int expected)
        {
            //Arrange

            //Act
            int actual = IterativeEven(input);

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

        [TestCase("paris", "sirap")]
        [TestCase("hannah", "hannah")]
        [TestCase("Z", "Z")]
        [TestCase("", "")]
        [TestCase("   ", "   ")]
        public void ReverseText_Test(string input, string expected)
        {
            //Arrange

            //Act
            var actual = ReverseText(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ReverseText_NullValue_Test()
        {
            //Arrange
            string input = null;
            string expected = null;

            //Act
            var actual = ReverseText(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Övning 1.1: ExamineList()
        /// Svar 1.2: En tom lista får kapaciteten 0.
        /// </summary>
        public void ExamineList_EmptyList_Test()
        {
            //Arrange
            int expectedCapacity = 0;
            List<string> list;

            //Act
            list = new List<string>();
            int actualCapacity = 0;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        /// <summary>
        /// Övning 1.1: ExamineList()
        /// Svar 1.2: Kapacitets ökning: 0, 4, 8, 16, 32, 64, 128...
        /// När man lägger in första elementet ökar kapacitet från 0 till 4.
        /// När man lägger in femte elementet ökar kapacitet från 4 till 8 o.s.v
        /// </summary>
        /// <param name="elemNumber">Antal element som listan ska fyllas med</param>
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(16)]
        [TestCase(25)]
        [TestCase(100)]
        public void ExamineList_AddValues_Test(int elemNumber)
        {
            //Arrange
            var generatedString = string.Concat(System.Linq.Enumerable.Repeat("hej-", elemNumber))
                                        .TrimEnd(new char[] { '-' });

            string[] elements = generatedString.Split('-');

            List<string> actual = new List<string>();
            List<string> expected = new List<string>(elements);
            int expectedCapacity = expected.Capacity;
            StringBuilder content = new StringBuilder();

            //Log expected list count and capacity:
            content.Append($"Expected List Count: {expected.Count}");
            content.Append(Environment.NewLine);
            content.Append($"Expected List Capacity: {expected.Capacity}");
            content.Append(Environment.NewLine);
            content.Append('-', 30);
            content.Append(Environment.NewLine);

            //Act
            foreach (var element in elements)
            {
                ListHandler(element, actual, Operation.Add);
                content.Append($"Count: {actual.Count}");
                content.Append(Environment.NewLine);
                content.Append($"Capacity: {actual.Capacity}");
                content.Append(Environment.NewLine);
                content.Append(Environment.NewLine);
            }

            string filePath = string.Format(@"C:\Users\John\listCapacityLogs\logg_list_capacity_{0}_elems.txt", elemNumber);
            LoggListCapacity(filePath, content);

            //Assert
            //TODO: Check group assertion
            CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCapacity, actual.Capacity);
        }

        [TestCase(10)]
        public void ExamineList_RemoveValues_Test(int elemNumber)
        {
            //Arrange
            var generatedString = string.Concat(System.Linq.Enumerable.Repeat("hej-", elemNumber))
                            .TrimEnd(new char[] { '-' });

            string[] elements = generatedString.Split('-');

            List<string> actual = new List<string>(elements);
            List<string> expected = new List<string>();

            //Act
            while(actual.Count > 0)
            {
                ListHandler("hej", actual, Operation.Remove);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        private void LoggListCapacity(string filePath, StringBuilder content)
        {
            File.WriteAllText(filePath, content.ToString());
        }
    }
}
