namespace TimeTracking.Data.Repository.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IReportRepository Report { get; }
        Task SaveChangesAsync();
    }
}
