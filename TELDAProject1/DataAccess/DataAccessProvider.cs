using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TELDAProject1.Models;


namespace TELDAProject1.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSQLContext _context;
        public DataAccessProvider(PostgreSQLContext context)
        {
            _context = context;
        }
        public void AddRegionRecord(Region region)
        {
            _context.regiondirectory.Add(region);
            _context.SaveChanges();
        }
        public void UpdateRegionRecord(Region region)
        {
            _context.regiondirectory.Update(region);
            _context.SaveChanges();
        }
        public void DeleteRegionRecord(int id)
        {
            var entity = _context.regiondirectory.FirstOrDefault(t => t.id == id);
            _context.regiondirectory.Remove(entity);
            _context.SaveChanges();
        }
        public Region GetSingleRegion(int id)
        {
            return _context.regiondirectory.FirstOrDefault(t => t.id == id);
        }

        public List<Region> GetRegions()
        {
            return _context.regiondirectory.ToList();
        }
    }
}
