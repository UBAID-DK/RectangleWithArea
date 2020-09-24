using RectangularTask.Application.Interfaces;
using RectangularTask.Application.Tasks.Dto;
using RectangularTask.Application.Tasks.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangularTask.Infrastructure.Repository
    {
    /// <summary>
    ///  Repository pattern implementation
    /// </summary>
    public class Repository : IRepository
        {

        #region <Repostory Method Implementation>

        public double ComputeArea(double height, double width)
            {
            return height * width;
            }

        public double ComputePerimeter(double height, double width) => 2 * height + 2 * width;



        public string GetRectType(double height, double width)
            {
            string rectType = string.Empty;
            if (height > width)
                rectType = "Tall";
            else if (height < width)
                rectType = "Flat";
            else if (height == width)
                rectType = "Square";
            return rectType;
            }

        public List<RectDto> GetUserInput(double[,] userInput)
            {
            var rectDtos = new List<RectDto>();
            for (int arrLength = userInput.GetUpperBound(0); arrLength >= 0; arrLength--)
                {

                if (Extension.IsParamsValid(userInput[arrLength, 0], userInput[arrLength, 1]))
                    {
                    RectDto.rectDto.Height = userInput[arrLength, 0];
                    RectDto.rectDto.Width = userInput[arrLength, 1];
                    double result = ComputeArea(RectDto.rectDto.Height, RectDto.rectDto.Width);

                    rectDtos.Add(new RectDto()
                        {
                        ID = arrLength,
                        Height = RectDto.rectDto.Height,
                        Width = RectDto.rectDto.Width,
                        Area = ComputeArea(RectDto.rectDto.Height, RectDto.rectDto.Width),
                        Perimeter = ComputePerimeter(RectDto.rectDto.Height, RectDto.rectDto.Width),
                        RectType = GetRectType(RectDto.rectDto.Height, RectDto.rectDto.Width)
                        });
                    }
                }
            return rectDtos;
            }
        public bool DisplayResult(string userInput)
            {
            bool status = true;
            var rectangles = Extension.SortedBy<List<RectDto>>(
                GetUserInput(Extension.UsreInputConversion<double[,]>(userInput)))
                .Select(x => new { x.Height, x.Width, x.RectType, x.Perimeter, x.Area }).ToList();
            if (rectangles.Count() > 0)
                {

                Console.WriteLine("\nSummary of Rectangle / Rectangles Measurements\n\n");
                foreach (var dto in rectangles)
                    {
                    Console.WriteLine(dto);

                    }
                }
            else
                {
                Console.WriteLine(" User input valus is invalid format/ have no value\n");
                }
            return status;
            }

        #endregion
        }
    }
