using ENGIE.CC.RESTAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace ENGIE.CC.RESTAPI.Services
{

    public interface IProductionPlanGenerator
    {
        List<ProductionPlanResponseItem> Generate(ProductionPlanPayload payload);
    }
    public class ProductionPlanGenerator : IProductionPlanGenerator
    {
        public List<ProductionPlanResponseItem> Generate(ProductionPlanPayload payload)
        {
            List<ProductionPlanResponseItem> pplan = new List<ProductionPlanResponseItem>();

            var gazPowerPlants = payload.PowerPlants.Where(x => x.Type == "gasfired").ToList();
            var kerosinePowerPlants = payload.PowerPlants.Where(x => x.Type == "turbojet").ToList();
            var windPowerPlants = payload.PowerPlants.Where(x => x.Type == "windturbine").ToList();

            var powerPlants = windPowerPlants.Union(gazPowerPlants).Union(kerosinePowerPlants).ToList();

            var desiredLoad = payload.Load;
            powerPlants.ForEach(x =>
            {
                if (desiredLoad <= 0)
                {
                    pplan.Add(new ProductionPlanResponseItem { Name = x.Name, P = 0.0 });

                }
                else
                {
                    var pp = x.CalculateProductionPlan(desiredLoad, payload.Fuels.Wind);
                    desiredLoad -= pp.P;
                    pplan.Add(pp);
                }

            });

            return pplan;

        }


    }
}
