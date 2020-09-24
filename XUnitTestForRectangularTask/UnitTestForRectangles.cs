
using RectangularTask.Application.Tasks.Dto;
using RectangularTask.Application.Tasks.Extensions;
using RectangularTask.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestForRectangularTask
    {
    public class UnitTestForRectangles
        {
        readonly UnitOfWork _unitOfWork;

        #region <Construcgor>
        public UnitTestForRectangles()
            {
            _unitOfWork = new UnitOfWork(new Repository());
            }
        #endregion

        #region <Standard format for testing method>
        // Testing / Unit Test Method Standard Format 

        // Arrange  
        // Act 
        // Assert  

        //Assert.Equal(expectedValue, actual Result); 

        // Note: i have define first / arrange case in class constructor so this is why i use onlye (act and assert)
        #endregion

        #region <All Testing Method For Rectangular>
        /// <summary>
        /// Test method take two parameter height and width and return Area of rectangular
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="expectedResult"></param>
        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(6, 9, 54)]
        [InlineData(4, 5, 20)]
        public void Computer_RectanglesArea_ReturnArea(double height, double weight, double expectedResult)
            {
            var actualResult = _unitOfWork.Tasks.ComputeArea(height, weight);
            Assert.Equal(expectedResult, actualResult);
            }
        /// <summary>
        /// Test method take 2 parameter height and width and return rectanguler Premiter
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="expectedResult"></param>
        [Theory]
        [InlineData(3, 4, 14)]
        [InlineData(6, 9, 30)]
        [InlineData(4, 5, 18)]
        public void Computer_RectanglesPerimeter_ReturnPremiter(double height, double weight, double expectedResult)
            {
            var actualResult = _unitOfWork.Tasks.ComputePerimeter(height, weight);
            Assert.Equal(expectedResult, actualResult);
            }
        /// <summary>
        /// Test Method taking two parameters (height and width)
        /// on behalf of params result show that rectangle is flat / tall / square.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="expectedRectType"></param>
        [Theory]
        [InlineData(3, 7, "Flat")]
        [InlineData(9, 6, "Tall")]
        [InlineData(4, 4, "Square")]
        public void Get_RectanglesType_ReturnRectangleType(double height, double weight, string expectedRectType)
            {
            var actualRectType = _unitOfWork.Tasks.GetRectType(height, weight);
            Assert.Equal(expectedRectType, actualRectType);
            }
        /// <summary>
        /// test method take user input as a single or more than one rectangle in given format for single rectangle [[2,2]]
        /// for more than one / for two rectangle [[3,4],[5,7]] and so on..
        /// and return list of rectangles which sorted by Area Descending.
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="expectedRectResult"></param>
        [Theory]
        [MemberData(nameof(UserInputWithExpectedOutDatalIST))]
        public void Get_UserInput_ReturnRectangles(string userInput, List<RectDto> expectedRectResult)
            {
            var actualRectType = _unitOfWork.Tasks.GetUserInput(Extension.UsreInputConversion<double[,]>(userInput));
            var actualColumnsWithVlaues = actualRectType.Select(x => new { x.Height, x.Width, x.RectType, x.Perimeter, x.Area }).ToList();
            var expectedColumnsWithValues = expectedRectResult.Select(x => new { x.Height, x.Width, x.RectType, x.Perimeter, x.Area }).ToList();
            Assert.Equal(expectedColumnsWithValues, actualColumnsWithVlaues);
            }
        /// <summary>
        /// Taking user input and then Display the expected result
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="exptectedValue"></param>
        [Theory]
        [InlineData("[[3,4],[5,6]]", true)]
        [InlineData("[[7,8],[4,5]]", true)]
        [InlineData("[[1,5],[9,2]]", true)]
        public void Get_UserInput_AndDisplayResult(string userInput, bool exptectedValue)
            {
            var actualRectType = _unitOfWork.Tasks.DisplayResult(userInput);
            Assert.Equal(exptectedValue, actualRectType);
            }
        #endregion

        #region<Custom / List Of User Input Data With Expected Result / Value>
        /// <summary>
        /// Customes user input / Test input with expected result
        /// </summary>
        /// <returns>return rectangles input and their output like height,width, area,perimeter and with their type </returns>
        public static IEnumerable<object[]> UserInputWithExpectedOutDatalIST()
            {

            yield return new object[] { "[[6,6]]", new List<RectDto>() { (new RectDto() { Height = 6, Width = 6, Area = 36, Perimeter = 24, RectType = "Square" }) } };
            yield return new object[] { "[[7,5]]", new List<RectDto>() { (new RectDto() { Height = 7, Width = 5, Area = 35, Perimeter = 24, RectType = "Tall" }) } };
            yield return new object[] { "[[4,8]]", new List<RectDto>() { (new RectDto() { Height = 4, Width = 8, Area = 32, Perimeter = 24, RectType = "Flat" }) } };
            }
        #endregion
        }
    }
