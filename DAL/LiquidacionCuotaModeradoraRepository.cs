using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        
        string ruta = @"Liquidacion.txt";
        List<LiquidacionCuotaModeradora> Listaliquidaciones;

        public string Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{liquidacion.NumeroLiquidacion};{liquidacion.IdentificacionPaciente};{liquidacion.TipoAfilicion};{liquidacion.SalarioDevengado}" +
                $";{liquidacion.ValorServicio};{liquidacion.TopeMaximo};{liquidacion.Tarifa};{liquidacion.CuotaModerada}");
            escritor.Close();
            file.Close();
            return "Guardado Correctamente ";
        }
        public List<LiquidacionCuotaModeradora> Consultar()
        {
            Listaliquidaciones = new List<LiquidacionCuotaModeradora>();

            string Linea = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader escritor = new StreamReader(file);
            while ((Linea = escritor.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModerada = Mapear(Linea);
                Listaliquidaciones.Add(liquidacionCuotaModerada);
            }
            escritor.Close();
            file.Close();

            return Listaliquidaciones;
        }
        public LiquidacionCuotaModeradora Mapear(string linea)
        {
            LiquidacionCuotaModeradora liquidacion = new Contributiva();
            char delimiter = ';';
            string[] Datos = linea.Split(delimiter);
            liquidacion.NumeroLiquidacion = Datos[0];
            liquidacion.IdentificacionPaciente = Datos[1];
            liquidacion.TipoAfilicion = Datos[2];
            liquidacion.SalarioDevengado = Convert.ToDecimal(Datos[3]);
            liquidacion.ValorServicio = Convert.ToDecimal(Datos[4]);
            liquidacion.TopeMaximo = Convert.ToDecimal(Datos[5]);
            liquidacion.Tarifa = Convert.ToDecimal(Datos[6]);
            liquidacion.CuotaModerada = Convert.ToDecimal(Datos[7]);

            return liquidacion;
        }
        public void Eliminar(string numeroLiquidacion)
        {
            Listaliquidaciones.Clear();
            Listaliquidaciones = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in Listaliquidaciones)
            {
                if (item.NumeroLiquidacion != numeroLiquidacion)
                {
                    Guardar(item);

                }
            }
        }
        public void Modificar(LiquidacionCuotaModeradora liquidacion)
        {
            Listaliquidaciones.Clear();
            Listaliquidaciones = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in Listaliquidaciones)
            {
                if (item.NumeroLiquidacion != liquidacion.NumeroLiquidacion)
                {
                    Guardar(item);
                }
                else
                {
                    liquidacion.LiquidacionCuotaModerada();

                    Guardar(liquidacion);
                }
            }
        }
        public LiquidacionCuotaModeradora ConsultaIndividual(string numeroLiquidacion)
        {
            Listaliquidaciones.Clear();
            Listaliquidaciones = Consultar();
            foreach (var item in Listaliquidaciones)
            {
                if (item.NumeroLiquidacion == numeroLiquidacion)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
