using RectangularTask.Application.Tasks.Extensions;
using RectangularTask.Infrastructure.Repository;
using System;

namespace DanskBankRectangularTask
    {
    class Program
        {
        #region <Main Class With Description >
        /// <summary>
        /// Programming taking rectangle height and width as input and then return rectangle with 
        /// calculated area, perimeter and ordering by area desc order
        /// </summary>
        /// <param name="userInput=Console.ReadLine()"></param>
        static void Main(string[] args)
            {
            //Dummy user input / rectangles vaues    [[3,5],[6,6],[2,1],[9,4],[9,1]]
            Console.Clear();
            Extension.UserIntruction();
            UnitOfWork rectangles = new UnitOfWork(new Repository());
            if (rectangles.Tasks.DisplayResult(Console.ReadLine()))
                Console.ReadKey();

            }

        #endregion
        }
    }
