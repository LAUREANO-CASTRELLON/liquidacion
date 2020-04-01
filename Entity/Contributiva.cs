namespace Entity
{
    public class Contributiva : LiquidacionCuotaModeradora
    {


        public override decimal ObtenerTarifa()
        {
            if (SalarioDevengado < 2)
            {
                return 15;
            }
            else if (SalarioDevengado >= 2 && SalarioDevengado <= 5)
            {
                return 20;
            }
            else
            {
                return 25;
            }
        }

        public override decimal ObtenerTope()
        {
            if (SalarioDevengado < 2)
            {
                return 250000;
            }
            else if (SalarioDevengado >= 2 && SalarioDevengado <= 5)
            {
                return 90000;
            }
            else
            {
                return 1500000;
            }
        }
    }
}
