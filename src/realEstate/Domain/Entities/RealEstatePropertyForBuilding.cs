using Domain.Enums;

namespace Domain.Entities;
public class RealEstatePropertyForBuilding : RealEstate
{
    public byte RoomCount { get; set; }

    public byte Floor { get; set; }

    public byte BuildingFloors { get; set; }

    public byte BuildingAge { get; set; }

    public HeatingSystemType HeatingType { get; set; }

}
