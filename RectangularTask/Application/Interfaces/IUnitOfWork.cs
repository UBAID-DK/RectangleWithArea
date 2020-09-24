namespace RectangularTask.Application.Interfaces
    {
    /// <summary>
    /// Unit of Work is referred to as a single transaction 
    /// that involves multiple operations of insert/update/delete and so on. 
    /// Unit of Work is the concept related to the effective implementation of the Repository Pattern
    /// </summary>
    public interface IUnitOfWork
        {
        #region <Unit Of Work Intercace Method>
        IRepository Tasks { get; }

        #endregion
        }
    }
