using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Common.CrossCutting.Interfaces
{
    public interface IEntityTranslation
    {
        public string LanguageCode { get; set; }
    }
}
