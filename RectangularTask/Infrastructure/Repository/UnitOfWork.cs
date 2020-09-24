using RectangularTask.Application.Interfaces;

namespace RectangularTask.Infrastructure.Repository
    {
    /// <summary>
    /// unit of work implementation
    /// </summary>
    public class UnitOfWork : IUnitOfWork
        {
        #region <Unit Of Work Implementation>
        public UnitOfWork(IRepository repository)
            {
            Tasks = repository;
            }

        #endregion
        public IRepository Tasks { get; }
        }
    }
