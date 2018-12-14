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

        /// <summary>
        /// Öving 5.2: RecursiveEven
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
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

        /// <summary>
        /// Övning 6.2: Iterative Even
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
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

        /// <summary>
        /// Övning 4.2: Check Parentheses Wellformed
        /// </summary>
        /// <param name="wellFormed"></param>
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

        /// <summary>
        /// Övning 4.2: Check parentheses Malformed
        /// </summary>
        /// <param name="malFormed"></param>
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

        /// <summary>
        /// Övning 6.3 Iterative fibonacci
        /// </summary>
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

        /// <summary>
        /// Övning 3.2: Reverse text
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestCase("paris", "sirap")]
        [TestCase("hannah", "hannah")]
        [TestCase("nitalarbralatin", "nitalarbralatin")]
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

        /// <summary>
        /// Övning 3.2: Reverse text null value.
        /// </summary>
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
        /// Svar 1.2: När man ska lägga till en element och det inte finns utrymme för detta element
        /// E.g när man ska lägga till femte elementet och kapaciteten ligger på fyra.
        /// Svar 1.3: Kapacitets ökar med Två potens: 0, 4, 8, 16, 32, 64, 128...
        /// Svar 1.4: Kapaciteten ökar inte vid varje element som läggs till eftersom 
        /// hela underliggande arrayen måste kopieras vilket är tidskrävande. 
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

            //Info about expected list count and capacity:
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

            //Log content.
            string filePath = string.Format(@"C:\Users\John\listCapacityLogs\logg_list_capacity_{0}_elems.txt", elemNumber);
            LoggListCapacity(filePath, content);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCapacity, actual.Capacity);
        }

        /// <summary>
        /// Övning 1.1: ExamineList()
        /// Svar 1.5: Kapaciteten minskar inte när man tar bort element från listan. Man kan dock använda sig av metoden TrimExess().
        /// Svar 1.6: Använd arrays när man inte behöver ändra på datastrukturens storlek samt när man är i behov av bättre prestanda. 
        /// </summary>
        /// <param name="elemNumber"></param>
        [TestCase(50)]
        [TestCase(1000)]
        public void ExamineList_RemoveValues_Test(int elemNumber)
        {
            //Arrange
            int expectedCapacity = elemNumber;
            var generatedString = string.Concat(System.Linq.Enumerable.Repeat("hej-", elemNumber)).TrimEnd(new char[] { '-' });
            string[] elements = generatedString.Split('-');
            List<string> list = new List<string>(elements);
            var content = new StringBuilder();

            content.Append($"Start number of elements: {elemNumber}");
            content.Append(Environment.NewLine);
            content.Append('-', 30);
            content.Append(Environment.NewLine);

            //Act
            while (list.Count > 0)
            {
                ListHandler("hej", list, Operation.Remove);
                content.Append($"Count: {list.Count}");
                content.Append(Environment.NewLine);
                //TODO: Test with TrimExess()
                //list.TrimExcess(); //To trim the Capacity of the list.
                content.Append($"Capacity: {list.Capacity}");
                content.Append(Environment.NewLine);
                content.Append(Environment.NewLine);
            }

            //Log content.
            string filePath = string.Format(@"C:\Users\John\listCapacityLogs\logg_list_capacity_{0}_removeElems.txt", elemNumber);
            LoggListCapacity(filePath, content);

            //Assert
            Assert.AreEqual(expectedCapacity, list.Capacity);
        }

        private void LoggListCapacity(string filePath, StringBuilder content)
        {
            File.WriteAllText(filePath, content.ToString());
        }
    }
}
