using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.Base
{
    public class BaseModel : IBaseModel
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual int? UpdatedBy { get; set; }
    }

    public class BaseModel<TKey> : BaseModel, IBaseModel<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
