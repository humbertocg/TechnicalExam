using System;
using Microsoft.Extensions.DependencyInjection;

namespace TechnicalExam.Services.Local
{
    public class LocalDependencyService : IDependecyService
    {
        public T Get<T>() where T : class
        {
            return IoCContainer.Container.GetRequiredService<T>();
        }
    }
}
