using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;
        
        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }
        public string Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            return liquidacionCuotaModeradoraRepository.Guardar(liquidacion);
        }
        public List<LiquidacionCuotaModeradora> Consultar()
        {
            return liquidacionCuotaModeradoraRepository.Consultar();
        }
        public void Eliminar(string numeroLiquidacion)
        {
            liquidacionCuotaModeradoraRepository.Eliminar(numeroLiquidacion);
        }
        public void Modificar(LiquidacionCuotaModeradora liquidacion)
        {
            liquidacionCuotaModeradoraRepository.Modificar(liquidacion);
            
        }
        public LiquidacionCuotaModeradora ConsultaIndividual(string numeroLiquidacion)
        {
            return liquidacionCuotaModeradoraRepository.ConsultaIndividual(numeroLiquidacion);
        }
    }
        
    
}
