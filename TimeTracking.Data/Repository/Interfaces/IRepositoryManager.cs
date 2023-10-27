namespace TimeTracking.Data.Repository.Interfaces
{
    internal interface IRepositoryManager
    {
        IUserRepository User { get; }
        IReportRepository Report { get; }
        Task SaveAsync();
    }
}
