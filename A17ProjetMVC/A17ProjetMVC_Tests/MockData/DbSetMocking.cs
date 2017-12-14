using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace A17ProjetMVC_Tests.MockData
{
    public static class DbSetMocking
    {
        public static Mock<DbSet<T>> CreateMockSet<T>(List<T> data)
           where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(queryableData.GetEnumerator());
            mockSet.Setup(set => set.Add(It.IsAny<T>())).Callback<T>(data.Add);
            mockSet.Setup(set => set.AddRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>(data.AddRange);
            mockSet.Setup(set => set.Remove(It.IsAny<T>())).Callback<T>(t => data.Remove(t));
            mockSet.Setup(set => set.RemoveRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>(ts =>
            {
                foreach (var t in ts) { data.Remove(t); }
            });
            return mockSet;
        }
    }
}
