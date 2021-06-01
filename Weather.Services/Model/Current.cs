using System.Collections.Generic;

namespace Weather.Services.Model
{
    public class Current
    {
        public List<string> Weather_Descriptions { get; set; }
        public double Wind_Speed { get; set; }
        public double UV_Index { get; set; }
    }
}
