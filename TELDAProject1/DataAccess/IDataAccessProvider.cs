using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TELDAProject1.Models;

namespace TELDAProject1.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddRegionRecord(Region region);
        void UpdateRegionRecord(Region region);
        void DeleteRegionRecord(int id);
        Region GetSingleRegion(int id);
        List<Region> GetRegions();
    }
}
