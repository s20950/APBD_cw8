using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cw8.Models.DTO.Requests;
using Cw8.Models.DTO.Responses;

namespace Cw8.Services
{
    public class DatabaseServise : IDatabaseService
    {
        private readonly s20950Context _context;

        public DatabaseServise(s20950Context context)
        {
            _context = context;
        }

        public async Task<PrescriptionResponseDto> GetPrescription(int IdPrescription)
        {
            return await _context.Prescriptions
                .Where(x => x.IdPrescription == IdPrescription)
                .Select(x => new PrescriptionResponseDto
                {
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Patient = new PatientResponseDto
                    {
                        FirstName = x.PatientNavigation.FirstName,
                        LastName = x.PatientNavigation.LastName,
                        Birthdate = x.PatientNavigation.Birthdate
                    },
                    Doctor = new DoctorResponseDto
                    {
                        IdDoctor = x.DoctorNavigation.IdDoctor,
                        FirstName = x.DoctorNavigation.FirstName,
                        LastName = x.DoctorNavigation.LastName,
                        Email = x.DoctorNavigation.Email
                    },
                    Medicaments = x.PrescriptionMedicaments.Select(x => new MedicamentResponseDto
                    {
                        Name = x.MedicamentNavigation.Name,
                        Description = x.MedicamentNavigation.Description,
                        Type = x.MedicamentNavigation.Type
                    }).ToList()
                }
                ).FirstAsync();
        }
        public async Task<DoctorResponseDto> GetDoctor(int IdDoctor)
        {
            return await _context.Doctors.Select(
                    x => new DoctorResponseDto
                    {
                        IdDoctor = x.IdDoctor,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email
                    }
                ).Where(e => e.IdDoctor == IdDoctor).FirstAsync();
        }
        public async Task<HttpStatusCodeResult> AddDoctor(DoctorRequestDto Doctor)
        {
            var doctor = await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = Doctor.FirstName,
                LastName = Doctor.LastName,
                Email = Doctor.Email
            });
            await _context.SaveChangesAsync();
            return new HttpStatusCodeResult(200, "Doktor dodany");
        }
        public async Task<HttpStatusCodeResult> UpdateDoctor(DoctorRequestDto Doctor, int IdDoctor)
        {
            var doctorExists = await _context.Doctors.Where(x => x.IdDoctor == IdDoctor).CountAsync();
            if (doctorExists > 0)
            {
                var d = await _context.Doctors.Where(x => x.IdDoctor == IdDoctor).FirstAsync();
                _context.Doctors.Remove(d);
                await _context.Doctors.AddAsync(new Doctor
                {
                    IdDoctor = IdDoctor,
                    FirstName = Doctor.FirstName,
                    LastName = Doctor.LastName,
                    Email = Doctor.Email
                });
                await _context.SaveChangesAsync();
                return new HttpStatusCodeResult(200, "Doktor zaktualizowany");
            }
            else
            {
                return new HttpStatusCodeResult(404, "Brak doktora o podanym ID");
            }
        }
        public async Task<HttpStatusCodeResult> DeleteDoctor(int IdDoctor)
        {
            var doctorExists = await _context.Doctors.Where(x => x.IdDoctor == IdDoctor).CountAsync();
            if (doctorExists > 0)
            {
                var doctor = await _context.Doctors.Where(x => x.IdDoctor == IdDoctor).FirstAsync();
                var prescriptionRecords = await _context.Prescriptions.Where(x => x.IdDoctor == IdDoctor).ToListAsync();

                foreach (var p in prescriptionRecords)
                {
                    var prescriptionMedicamentRecords =
                        await _context.PrescriptionMedicaments
                        .Where(x => x.IdPrescription == p.IdPrescription).ToListAsync();
                    foreach (var pm in prescriptionMedicamentRecords)
                        _context.PrescriptionMedicaments.Remove(pm);
                    _context.Prescriptions.Remove(p);
                }
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return new HttpStatusCodeResult(200, "Doktor usunięty");
            }
            else
            {
                return new HttpStatusCodeResult(404, "Brak doktora o podanym ID");
            }
        }

        public async Task<HttpStatusCodeResult> DoctorExists(int IdDoctor)
        {
            var exists = await _context.Doctors.Where(x => x.IdDoctor == IdDoctor).CountAsync();
            return exists > 0 ? new HttpStatusCodeResult(200) : new HttpStatusCodeResult(404, "Doktor nie istnieje");
        }

        public async Task<HttpStatusCodeResult> PrescriptionExists(int IdPrescription)
        {
            var exists = await _context.Prescriptions.Where(x => x.IdPrescription == IdPrescription).CountAsync();
            return exists > 0 ? new HttpStatusCodeResult(200) : new HttpStatusCodeResult(404, "Recepta nie istnieje");
        }
    }
}