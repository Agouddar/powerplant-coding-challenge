namespace ENGIE.CC.RESTAPI.Models;

public class PowerPlant
{

    public string Name { get; set; }
    public string Type { get; set; }
    public double Efficiency { get; set; }
    public double Pmin { get; set; }
    public double Pmax { get; set; }
    public PowerPlant()
    {

    }

    public ProductionPlanResponseItem CalculateProductionPlan(double desiredLoad, double wind)
    {

        double production = 0.0;
        if (Type == "windturbine")
        {
            production = Math.Round((wind > 0 ? Math.Min((wind / 100) * Pmax / Efficiency, desiredLoad) : 0.0), 2);
        }
        else
        {
            production = Math.Round(Math.Max(Pmin, Math.Min(desiredLoad / Efficiency, Pmax)), 2);
        }

        return new ProductionPlanResponseItem { Name = Name, P = desiredLoad < production ? desiredLoad : production };
    }

}


