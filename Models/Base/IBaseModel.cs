using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public interface IBaseModel<TKey> : IBaseModel
    {
        TKey Id { get; }
    }

    public interface IBaseModel
    {
    }
}
