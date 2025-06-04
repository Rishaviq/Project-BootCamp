using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Repositories.BaseClasses;

namespace Office.Repositories.Interfaces.WorkSpace
{
    public interface IWorkSpaceRepository:IBaseRepository<Models.WorkSpace, WorkSpaceFilter, WorkSpaceUpdate>
    {
    }
}
