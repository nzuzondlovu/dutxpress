using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDutExpressSystem.Models
{
    class GetResults
    {
        public IEnumerable<Information_TechnologyModel> InfoTech { get; set; }
        public IEnumerable<Chemical_EngineeringModel> ChemE { get; set; }
        public IEnumerable<Social_ScienceModel> Social { get; set; }
        public IEnumerable<Aerospace_StudiesModel> AA { get; set; }
    }
}
