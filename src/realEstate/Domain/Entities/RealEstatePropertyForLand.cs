using Domain.Enums;

namespace Domain.Entities;
public class RealEstatePropertyForLand : RealEstate
{
    public ZoningStatus ZoningStatus { get; set; }

    public string Block { get; set; }

    public string Parcel { get; set; }

    public decimal BuildingCoverageRatio { get; set; }

    public decimal FloorAreaRatio { get; set; }


}
