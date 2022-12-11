using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper.Interfaces
{
    public interface IHttpClientService
    {
        T SendRequest<T>(IRequestBuilder request);
    }
}
