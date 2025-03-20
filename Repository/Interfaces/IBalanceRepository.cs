using SistemaDeRecarga.Model;

public interface IBalanceRepository
{
    Task<Balance> GetBalanceByUserIdAsync(int idUser);
    Task CreateBalanceAsync(Balance balance);
    Task UpdateBalanceAsync(Balance balance);
}