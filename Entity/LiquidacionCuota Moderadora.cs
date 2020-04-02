using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradora
    {
        public const decimal SALARIO = 980657;
        public int NumeroLiquidación { get; set; }
        public string IdPaciente { get; set; }
        public string TipoAfilicacion { get; set; }
        public decimal SalarioDevengado { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal ValorCuotaModeradora { get; set; }
        public void CalcularValorCuotaModeradora(decimal valorServicio, decimal salarioPaciente)
        {
            this.ValorCuotaModeradora = 0;
            decimal tarifa = CalcularTarifa(salarioPaciente);
            this.ValorCuotaModeradora = valorServicio * tarifa;
            if (this.ValorCuotaModeradora != 0)
            {
                this.ValorCuotaModeradora = ValidarTope(salarioPaciente, this.ValorCuotaModeradora);
            }
        }
        public void CalcularValorCuotaModeradora(decimal valorServicio)
        {
            const decimal TARIFA = 0.05M;
            this.ValorCuotaModeradora = 0;
            this.ValorCuotaModeradora = (valorServicio + valorServicio * TARIFA);
            if (this.ValorCuotaModeradora != 0)
            {
                if (this.ValorCuotaModeradora > 200000)
                {
                    this.ValorCuotaModeradora = 200000;
                }
            }
        }
        private static decimal ValidarTope(decimal salarioPaciente, decimal valorCuota)
        {
            if (((2 * SALARIO) > salarioPaciente) && (valorCuota > 250000))
            {
                valorCuota = 250000;
            }
            if ((salarioPaciente >= (2 * SALARIO) && (5 * SALARIO) >= salarioPaciente) && (valorCuota > 900000))
            {
                valorCuota = 900000;
            }
            if ((salarioPaciente > (5 * SALARIO)) && (valorCuota > 1500000))
            {
                valorCuota = 1500000;
            }

            return valorCuota;

        }

        public decimal CalcularTarifa(decimal salario)
        {
            if ((2 * SALARIO) > salario)
            {
                return 0.015M;
            }
            if (salario >= (2 * SALARIO) && (5 * SALARIO) >= salario)
            {
                return 0.20M;
            }
            if (salario > (5 * SALARIO))
            {
                return 0.25M;
            }
            return 0;
        }
    }
}

    



