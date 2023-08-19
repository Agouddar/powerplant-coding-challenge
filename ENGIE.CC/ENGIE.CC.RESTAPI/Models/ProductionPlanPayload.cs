namespace ENGIE.CC.RESTAPI.Models;

public class ProductionPlanPayload
{

    public double Load { get; set; }
    public FuelsCost Fuels { get; set; }

    public List<PowerPlant> PowerPlants { get; set; } = new List<PowerPlant>();
    public ProductionPlanPayload()
    {

    }
}
