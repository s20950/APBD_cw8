using System.Collections.Generic;

namespace Cw8.Models
{
    public class Medicament
    {
        public Medicament()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }

        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}