using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface ISensorRepository
    {
        MeasureValue GetData();
    }
}
