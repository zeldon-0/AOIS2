using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Repositories.Contracts;
using AOIS2.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Data.Repositories
{
    public class RadicalRepository : IRadicalRepository
    {
        private DataStorageContext _context;
        public RadicalRepository(DataStorageContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Radical>> GetAllRadicalsAsync()
        {
            IEnumerable<Radical> radicals =
                await _context.Radicals.ToListAsync();

            return radicals;
        }
    }
}
