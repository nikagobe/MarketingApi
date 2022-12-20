using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Implementations.Helper
{
    public static class DbConnectionWrapper
    {
        public static async Task RunAsTransaction(Func<IDbConnection, IDbTransaction, Task> function, IDbConnection connection)
        {
            using IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                await function.Invoke(connection, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static async Task<T> RunAsTransaction<T>(Func<IDbConnection, IDbTransaction, Task<T>> function, IDbConnection connection)
        {
            using IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var res = await function.Invoke(connection, transaction);
                transaction.Commit();
                return res;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
