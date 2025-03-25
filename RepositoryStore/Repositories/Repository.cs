using Microsoft.EntityFrameworkCore;
using RepositoryStore.Repositories.Abstractions;

namespace RepositoryStore.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
			_dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
		{
			await _dbSet.AddAsync(entity, cancellationToken);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async void DeleteAsync(T entity, CancellationToken cancellationToken = default)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task<List<T>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default)
			=>await _dbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync();

		public async Task<T?> GetById(int id, CancellationToken cancellationToken = default)
			=> await _dbSet.FindAsync(id, cancellationToken);

		public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return entity;
		}
	}
}
