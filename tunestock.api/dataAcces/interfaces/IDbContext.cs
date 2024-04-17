using System.Data.Common;

namespace tunestock.api.dataAccess.interfaces;
public interface IDbContext{
    DbConnection Connection { get; }
    
}