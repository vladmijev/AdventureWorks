using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
	public interface IRepository<TObject>
		where TObject : class
	{
		TObject Get(int id);
		Task<TObject> GetAsync(int id);

		ICollection<TObject> GetAll();
		Task<ICollection<TObject>> GetAllAsync();

		TObject Add(TObject item);
		TObject Update(TObject item, int key);
		void Delete(TObject item);

		int SaveChanges();
		Task<int> SaveCghangesAsync(CancellationToken cancellationToken);
	}
}
