using Centerhum.SmartFood.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.DataAccess.Map
{
    public class BoardMap : EntityTypeConfiguration<Board>
    {
        public BoardMap()
        {
            this.HasOptional(x => x.Client)
                .WithOptionalDependent();
        }
    }
}
