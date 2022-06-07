using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase creada para hacer testings Y AHORA PARA PROBAR GIT DESDE ESCRITORIO
/// </summary>
namespace RepasoGeneral
{
    public class CuentaBanco 
    {
        /// <summary>
        /// Parametros creados como privados, por refactorizacion
        /// </summary>
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;
        private CuentaBanco()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="balance"></param>
        public CuentaBanco(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        // incluyo constructor MPRG2122  no es correcto
        //  public ArgumentOutOfRangeException("amount", amount, error a 0 );


        // class under test MPRG2122 Siguiendo instrucciones
        /// <summary>
        /// 
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amountexceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount lessthan zero";

        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            get
            {
                return m_customerName;
            }
        }
        public double Balance
        {
            get
            {
                return m_balance;
            }
        }
        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }
            if (amount > m_balance)
            {
                // throw new ArgumentOutOfRangeException("amount");cambio a nuevo constructor MPRG2122
                //  throw new ArgumentOutOfRangeException("amount", amount, "Debit es mayor que saldo"); cambio x instrucción práctica
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);

            }
            if (amount < 0)
            {
                //  throw new ArgumentOutOfRangeException("amount"); cambio a nuevo constructor MPRG2122
                //  throw new ArgumentOutOfRangeException("amount", amount, "Debit es menor a 0"); cambio x instrucción práctica
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            }

            if (m_balance < 0)
            {
                //  throw new ArgumentOutOfRangeException("amount"); cambio a nuevo constructor MPRG2122
                //  throw new ArgumentOutOfRangeException("amount", amount, "Debit es menor a 0"); cambio x instrucción práctica
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            }
            m_balance -= amount; // intentionally incorrect code    MPRG2122 Arreglo 070422
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }
        public void FreezeAccount()
        {
            m_frozen = true;
        }
        public void UnfreezeAccount()
        {
            m_frozen = false;
        }
        public static void Main()
        {
            CuentaBanco ba = new CuentaBanco("Mr. Bryan Walton", 11.99
            );
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

    }
}
