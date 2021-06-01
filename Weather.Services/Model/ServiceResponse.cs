
namespace Weather.Services.Model
{
    public class ServiceResponse
    {
        public bool ZipCodeValid { get; set; } = true;
        public bool GoOutSide { get; set; } = false;
        public bool WearSunScreen { get; set; } = false;
        public bool FlyKite { get; set; } = false;
    }
}
