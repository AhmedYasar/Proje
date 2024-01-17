using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISepetService
    {
        IResult Add(Sepet sepet);
        IDataResult<Sepet> GetById(int sepetId);

        IResult Delete(Sepet sepet);

        IResult Odeme(Sepet sepet);

        IDataResult <List<Sepet>> GetByUserId(int userId);

        IResult Update(Sepet sepet);

    }
}
