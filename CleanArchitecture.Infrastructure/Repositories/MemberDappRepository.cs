using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using System.Data;
using Dapper;

namespace CleanArchitecture.Infrastructure.Repositories;

public class MemberDappRepository : IMemberDappRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberDappRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        
        if (_dbConnection.State != ConnectionState.Open)
        {
            _dbConnection.Open();
        }
    }
    
    private const string SqlMember = @"SELECT Id, Name, Email, About, BirthDate, Age, IsActive, Salary FROM t_members";

    public async Task<IEnumerable<Member>> GetAll() => await _dbConnection.QueryAsync<Member>(SqlMember);
    
    public async Task<Member> GetById(int id)
    {
        string sql = @"SELECT Name, Email, About, BirthDate, Age, IsActive, Salary FROM t_members WHERE Id = @Id";
        
        return await _dbConnection.QueryFirstAsync<Member>(sql, new { Id = id });
    }
}