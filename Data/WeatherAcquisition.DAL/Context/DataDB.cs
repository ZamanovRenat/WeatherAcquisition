using Microsoft.EntityFrameworkCore;

namespace WeatherAcquisition.DAL.Context
{
    public class DataDB : DbContext
    {
        public DataDB(DbContextOptions<DataDB> options) : base(options) { }
    }
}
