using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora { 
        public string NumeroLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string TipoAfilicion { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal SalarioDevengado { get; set; }

        public decimal CuotaModerada { get; set; }
        public decimal TopeMaximo { get; set; }
        public decimal Tarifa { get; set; }

        public abstract decimal ObtenerTarifa();
        public abstract decimal ObtenerTope();
        public decimal LiquidacionCuotaModerada()
        {
            Tarifa = ObtenerTarifa();
            TopeMaximo = ObtenerTope();
            CuotaModerada = ValorServicio * (Tarifa / 100) + ValorServicio;
            LiquidardarCuota();
            return CuotaModerada;
        }
        
        public void LiquidardarCuota()
        {
            if (CuotaModerada > TopeMaximo)
            {
                CuotaModerada = TopeMaximo;
            }
        }
    }
}
