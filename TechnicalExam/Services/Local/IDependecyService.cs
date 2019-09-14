using System;
namespace TechnicalExam.Services.Local
{
    public interface IDependecyService
    {
        T Get<T>() where T : class;
    }
}
