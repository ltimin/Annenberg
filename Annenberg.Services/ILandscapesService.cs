using System.Collections.Generic;
using Annenberg.Services.Domains;

namespace Annenberg.Services
{
    public interface ILandscapesService
    {
        List<AnnenbergLandscape> GetAll();
    }
}