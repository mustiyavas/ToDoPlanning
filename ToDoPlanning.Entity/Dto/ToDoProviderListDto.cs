using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Shared.Entity.Abstract;

namespace ToDoPlanning.Entity.Dto
{
    public class ToDoProviderListDto : DtoGetBase
    {
        public IList<ToDoProvider> ToDoProviders { get; set; }
    }
}
