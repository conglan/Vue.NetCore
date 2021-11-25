/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using VOL.System.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.System.Repositories
{
    public partial class vSysDictionaryRepository : RepositoryBase<vSysDictionary>, IvSysDictionaryRepository
    {
        public vSysDictionaryRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static IvSysDictionaryRepository Instance
        {
            get { return AutofacContainerModule.GetService<IvSysDictionaryRepository>(); }
        }
    }
}

