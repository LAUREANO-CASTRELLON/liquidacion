using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace LiquidacionUI
{
    class Program
    {public static LiquidacionCuotaModeradoraService liquidacionService = new LiquidacionCuotaModeradoraService();
        public static List<LiquidacionCuotaModeradora> Listaliquidaciones = new List<LiquidacionCuotaModeradora>();
        static void Main(string[] args)
        {
            int Opcion; 
                
            do {
                
                
                Console.WriteLine("1. Registrar y liquidar");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Modificar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Por favor digite la opcion");
                Opcion = Convert.ToInt32(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        LiquidacionCuotaModeradora liquidacion;
                        string Numero, Identificacion, Tipo;

                        Console.WriteLine("Por favor digite numero de la liquidacion");
                        Numero = Console.ReadLine();
                        Console.WriteLine("Por favor digite numero de Identificacion");
                        Identificacion = Console.ReadLine();
                        Console.WriteLine("Por favor digite tipo de afiliacion CONTRIBUTIVO o SUBSIDIADO");
                        Tipo = Console.ReadLine();
                        if (Tipo == "CONTRIBUTIVO")
                        {
                            liquidacion = new Contributiva();
                            Console.WriteLine("Por favor digite Salario Devengado;");
                            liquidacion.SalarioDevengado = Convert.ToDecimal(Console.ReadLine());
                        }
                        else
                        {
                            liquidacion = new Subsidiado();
                        }
                        liquidacion.NumeroLiquidacion = Numero;
                        liquidacion.IdentificacionPaciente = Identificacion;
                        liquidacion.TipoAfilicion = Tipo;

                        Console.WriteLine("Digite Valor del Servicio");
                        liquidacion.ValorServicio = Convert.ToDecimal(Console.ReadLine());

                        liquidacion.LiquidacionCuotaModerada();

                        Console.WriteLine(liquidacionService.Guardar(liquidacion));

                        break;
                    case 2:

                        Listaliquidaciones = liquidacionService.Consultar();
                        foreach (LiquidacionCuotaModeradora item in Listaliquidaciones)
                        {
                            Console.WriteLine($"Numero : {item.NumeroLiquidacion}");
                            Console.WriteLine($"Identificacion: {item.IdentificacionPaciente}");
                            Console.WriteLine($"Tipo De Afiliacion: {item.TipoAfilicion}");
                            Console.WriteLine($"Salario Devengado: {item.SalarioDevengado}");
                            Console.WriteLine($"Valor Del Servicio: {item.ValorServicio}");
                            Console.WriteLine($"Tope: {item.TopeMaximo}");
                            Console.WriteLine($"Cuota Moderada: {item.CuotaModerada}");
                            Console.WriteLine($"Tarifa: {item.Tarifa}");
                            
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite Numero de Liquidacion a Modificar: ");
                        liquidacion = liquidacionService.ConsultaIndividual(Console.ReadLine());
                        if (liquidacion != null)
                        {
                            Console.WriteLine("Digite el nuevo Valor de Servicio: ");
                            liquidacion.ValorServicio = Convert.ToDecimal(Console.ReadLine());
                            liquidacion.LiquidacionCuotaModerada();
                            liquidacionService.Modificar(liquidacion);
                            Console.WriteLine("Modificado Correctamente...");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el numero d eliquidacion a modificar");
                        }

                        break;
                    case 4:
                        Console.WriteLine("Digite Numero de Liquidacion que desea Eliminar: ");
                        liquidacion = liquidacionService.ConsultaIndividual(Console.ReadLine());
                        if (liquidacion != null)
                        {
                            //liquidacionService.Eliminar(liquidacion); Error
                            Console.WriteLine("Opcion no terminada ");
                            Console.ReadKey();
                            break;
                        }
                            break;
                    case 5:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("La opcion digitada no es valida");
                        break;
                }
                Console.ReadKey();
            } while (Opcion != 5);




            /*LiquidacionCuotaModeradora contributiva = new Contributiva(223, "923456", 10000000, 2);
            LiquidacionCuotaModeradora subsidiada = new Subsidiado(322, "183457", 100000);            
            contributiva.LiquidarCuota();
            subsidiada.LiquidarCuota();
            ImprimirLiquidacion(contributiva);
            Console.WriteLine("");
            Console.WriteLine("");
            ImprimirLiquidacion(subsidiada);

            Console.ReadKey();
        }        

        static void ImprimirLiquidacion(LiquidacionCuotaModeradora liquidacionCuota)
        {
            Console.WriteLine("Numero Liquidacion: " + liquidacionCuota.NumeroLiquidacion);
            Console.WriteLine("Identificacion paciente: " + liquidacionCuota.IdentificacionPaciente);
            Console.WriteLine("Salario paciente: " + liquidacionCuota.SalarioPaciente);
            Console.WriteLine("Tipo de afiliacion: " + liquidacionCuota.TipoAfilicion);
            Console.WriteLine("Valor Servicio: " + liquidacionCuota.ValorServicio);
            Console.WriteLine("Tarifa: " + liquidacionCuota.Tarifa);
            Console.WriteLine("Tope: " + liquidacionCuota.TopeMaximo);
            Console.WriteLine("Cuota a pagar: " + liquidacionCuota.ValorCuota);*/
        }
    }
}
