using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio82
{
    internal class Cuenta
    {
        private string idCuenta;

        public Cuenta(string prmtIdCuenta)
        {
            this.idCuenta = prmtIdCuenta;
            System.Console.WriteLine("Constructor Clase Base para cuenta{0} ", prmtIdCuenta);
        }

        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine("Cuenta.CalcularIntereses() efectuando para la cuenta {0} ", this.idCuenta);

        }

        public string getIdCuenta()
        {
            return this.idCuenta;
        }
    }

    internal class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string prmtIdCuenta) : base(prmtIdCuenta)
        {

        }
        public override void CalcularIntereses()
        {
            System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuando para la cuenta {0} ", getIdCuenta());
        }
    }

    internal class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string prmtIdCuenta) : base(prmtIdCuenta)
        {
        }

        public override void CalcularIntereses()
        {
            System.Console.WriteLine("CuentaAhorro.CalcularIntereses() efectuado para la cuenta {0} ", getIdCuenta());
        }
    }
}
