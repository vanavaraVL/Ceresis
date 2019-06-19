using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Infrastructure
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
