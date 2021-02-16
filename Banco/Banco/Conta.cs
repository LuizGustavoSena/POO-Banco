namespace Banco
{
    public class Conta
    {

        public int Agencia { get ; set ; }
        public int Numero { get ; set ; }
        public double Saldo { get ; set ; }

        // CONSTRUTORES
        public Conta()
        {
            Agencia = 0;
            Numero = 0;
            Saldo = 0;
        }
        public Conta(int agencia, int numero, double saldo)
        {
            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
        }

        // IMPRESSAO
        public override string ToString()
        {
            return ("Agencia: " + Agencia + " Número da conta: " + Numero + " Saldo: " + Saldo);
        }

        // METODOS
        public void Deposito(double value)
        {
            Saldo += value;
        }

        public void Saque(double value)
        {
            if (Saldo > 0 && (Saldo - value) >= 0)
                Saldo -= value;
        }
    }
}