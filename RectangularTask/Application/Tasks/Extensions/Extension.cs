using RectangularTask.Application.Tasks.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangularTask.Application.Tasks.Extensions
    {
    /// <summary>
    /// Commond extension method factory
    /// all common extension method has define within extension class
    /// </summary>
    public static class Extension
        {
        #region <Common Extension Methods>
        public static bool IsParamsValid(double height, double width)
            {
            if (height > 0 && width > 0)
                return true;
            else
                return false;
            }
        public static string GetRectType(double height, double width)
            {
            var rectType = string.Empty;
            if (height > width)
                rectType = "Tall";
            else if (height < width)
                rectType = "Flat";
            else if (height == width)
                rectType = "Square";
            return rectType;
            }
        public static bool CheckDoubleValue(double? areaValue)
            {
            if (areaValue == null || areaValue.GetValueOrDefault() == 0)
                return true;
            else
                return false;
            }

        public static T UsreInputConversion<T>(string userInput)
            {
            T result = default(T);
            try
                {
                result = (T)Convert.ChangeType(JsonConvert.DeserializeObject<T>(userInput), typeof(T));
                }
            catch (ArgumentException ex)
                {
                Console.WriteLine(ex.Message + " << Invalid Input >> ");
                }
            return result;
            }

        public static List<RectDto> SortedBy<T>(List<RectDto> list)
            {
            return list.OrderByDescending(x => x.Area).ThenBy(x => x.RectType).ToList();
            }

        public static void UserIntruction()
            {
            Console.WriteLine("\t*** PLEASE READ THE FOLLOWING INSTRUCTION CARE FULLY *** \n");
            Console.WriteLine("Rectangle values should be in this format");
            Console.WriteLine("   a) single rectangle values format  [[2,3]]");
            Console.WriteLine("   b) for more than one rectangle values format [[3, 4],[5, 6],[5, 7]]\n");
            Console.WriteLine("Please enter your input / rectangles values");
            Console.Write("User Input :");
            }

        #endregion
        }
    }
