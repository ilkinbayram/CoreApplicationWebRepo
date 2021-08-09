using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITagBlogDal : IEntityRepository<TagBlog>
    {
    }
}
