using RectangularTask.Application.Tasks.Dto;
using System.Collections.Generic;

namespace RectangularTask.Application.Interfaces
    {
    /// <summary>
    /// General interface Reporsitory for rectangle 
    /// </summary>
    public interface IRepository
        {
        #region <IRepository Interface Method>
        double ComputeArea(double height, double width);
        double ComputePerimeter(double height, double width);
        string GetRectType(double height, double width);
        List<RectDto> GetUserInput(double[,] userInput);
        bool DisplayResult(string userInput);

        #endregion
        }
    }
