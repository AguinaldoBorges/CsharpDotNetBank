using CsharpDotNetBank.Models;

namespace CsharpDotNetBank.Services;

public class ContaService
{
    private static readonly Conta _conta = new();

    public Conta ObterConta()
    {
        return _conta;
    }

    public void Depositar(decimal valor)
    {
        _conta.Saldo += valor;
    }

    public bool Sacar(decimal valor)
    {
        if (valor > _conta.Saldo)
            return false;

        _conta.Saldo -= valor;
        return true;
    }
}
