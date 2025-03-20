using SistemaDeRecarga.Model;
using System.Runtime.CompilerServices;

namespace SistemaDeRecarga.Business
{
    public class BalanceBusiness
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceBusiness(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task<Balance> GetBalanceByIdUserAsync(int idUser)
        {

            //Verificar se usuário existe
            var user = await _balanceRepository.GetBalanceByIdUserAsync(idUser);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            var balance = await _balanceRepository.GetBalanceByIdUserAsync(idUser);
            if(balance == null)
            {
                //Criar um saldo zerado se nao existir
                balance = new Balance
                {
                    IdUser = idUser,
                    Amount = 0,
                    LastUpdate = DateTime.Now
                };
                await _balanceRepository.CreateBalanceAsync(balance);
            }

            return user;
        }

        public async Task<Balance> AddBalanceAsync(int idUser, decimal valor)
        {
            if(valor <= 0)
            {
                throw new Exception("O vlor da recarga deve ser maior que zero");
            }

            //Obter ou criar saldo
            var balance = await GetBalanceByIdUserAsync(idUser);

            //Atualiza saldo
            balance.Amount += valor;
            balance.LastUpdate = DateTime.Now;
            await _balanceRepository.UpdateBalanceAsync(balance);

            return balance;
        }

        public async Task<Balance> DeductBalanceAsync(int idUser, decimal valor)
        {
            if(valor <= 0)
            {
                throw new Exception("O valor do débito deve ser maior que zero.");
            }

            //obter saldo
            var saldo = await GetBalanceByIdUserAsync(idUser);

            //verifica se há saldo suficiente
            if (saldo.Amount < valor)
            {
                throw new Exception("Saldo insuficiente.");
            }

            //atualizar saldo
            saldo.Amount -= valor;
            saldo.LastUpdate = DateTime.Now;
            await _balanceRepository.UpdateBalanceAsync(saldo);

            return saldo;
        }
    }


}
