
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic constraint
    //class:referans tip olabilir demektir.IEntitiy Ientity olabilir veya IEntity i implement eden bir nesne olabilir.new() ise new lenebilir olması lazım
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);

        T Get(Expression<Func<T, bool>> filter );

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
