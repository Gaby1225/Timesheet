using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Timesheet.Data.Context;
using Timesheet.Domain.Interfaces;
using Timesheet.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Timesheet.Data.Categorias
{
    public class CategoriaData : IGenerateMethodsCrud<Categoria>
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Categoria> Create(Categoria cat) //testar para cadastrar vários de uma vez
        {
            cat.Id = 0;

            _appDbContext.Categorias.Add(cat);
            await _appDbContext.SaveChangesAsync();

            return cat;
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _appDbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await _appDbContext.Categorias.FindAsync(id);
        }

        public async Task<Categoria> Update(Categoria cat)
        {
            _appDbContext.Categorias.Update(cat);
            await _appDbContext.SaveChangesAsync();
            return cat;
        }


        public async Task<Categoria> Delete(int id)
        {
            var cat = await _appDbContext.Categorias.FindAsync(id);
            _appDbContext.Categorias.Remove(cat);
            await _appDbContext.SaveChangesAsync();
            return cat;
        }


    }
}
