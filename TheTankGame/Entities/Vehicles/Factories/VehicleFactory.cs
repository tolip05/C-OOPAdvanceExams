using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            string assembler = "VehicleAssembler";
            Type typeAssembler = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == assembler);
            IAssembler assemblerClass = (IAssembler)Activator.CreateInstance(typeAssembler);

            Type types = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == vehicleType);
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(types, new object[]{
                 model,
                 weight,
                 price,
                 attack,
                 defense,
                 hitPoints,
                 assemblerClass
            });
            return vehicle;
        }
    }
}
