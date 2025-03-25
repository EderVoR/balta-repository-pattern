using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Models;
using RepositoryStore.Repositories.Abstractions;

namespace RepositoryStore.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
        {
        }

        //public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        //{
        //    await _context.Products.AddAsync(product, cancellationToken);
        //    await _context.SaveChangesAsync();

        //    return product;
        //}

        //public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        //{
        //    _context.Products.Update(product);
        //    await _context.SaveChangesAsync(cancellationToken);

        //    return product;
        //}

        //public async void DeleteAsync(Product product, CancellationToken cancellationToken = default)
        //{
        //    _context.Remove(product);
        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        //public async Task<Product?> GetById(int id, CancellationToken cancellationToken = default)
        //{
        //    var produto = await _context.Products
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        //    return produto;
        //}

        //public async Task<List<Product>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default)
        //{
        //    var produts = await _context.Products
        //        .AsNoTracking()
        //        .Skip(skip)
        //        .Take(take)
        //        .ToListAsync(cancellationToken);

        //    return produts;
        //}
    }
}
