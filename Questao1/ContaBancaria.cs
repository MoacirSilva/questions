using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Questao1
{
    class ContaBancaria {

        private int num;
        public string tit;
        private double sld = 0;

        public ContaBancaria(int numero, string titular)
        {
            num = numero;
            tit = titular;
        }
        public ContaBancaria(int numero, string titular, double depositoInicial) {

            num = numero;
            tit = titular;
            sld = depositoInicial;

        }

        public void Deposito(double valor)
        {
            sld += valor;
        }

        public void Saque(double valor)
        {
            sld -= valor;
            sld -= 3.50;
        }

        public override string ToString()
        {
            string msg = $"Conta {num}, Titular: {tit}, Saldo: $ {sld}";

            return msg;
        }

    }
}
