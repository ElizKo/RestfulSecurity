using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulSecurity.Models;
using RestfulSecurity.Database;
using System.Data.Entity;

namespace RestfulSecurity.Controllers
{
    //[Authorize]
    public class PatientsController : BaseController
    {
        //Return all patients
        [HttpGet]
        public IEnumerable<Patient> GetAllPatients()
        {
            return db.Patients;
        }

        // Return a patient based on its id
        [HttpGet]
        public Patient GetPatient(int id)
        {
            return db.Patients.ToList().Find(x => x.Id == id);
        }

        //Return all patients based on search filter
        [HttpGet]
        [Route("api/patients/search")]
        public IEnumerable<Patient> GetAllPatientsByKeyword([FromUri] string keyword)
        {
            // return all the patients in case the keyword is empty
            if (string.IsNullOrEmpty(keyword))
            {
                return this.GetAllPatients();
            }
            else
            {
                int result = 0;

                // filter the patients based on the provided keyword
                if (int.TryParse(keyword, out result))
                {
                    return db.Patients.Where(x => x.Age == result
                    || x.NumberOfEmbryos == result);
                }
                else
                {
                    return db.Patients.Where(x => x.FirstName.Contains(keyword)
                    || x.LastName.Contains(keyword));
                }
            }
        }

        [HttpGet]
        [Route("api/patients/{patientId}/files")]
        public IEnumerable<File> GetAllPatientFiles(int patientId)
        {
            return db.Files.Where(f => f.PatientID == patientId);
        }

        // Create a new patient
        [HttpPost]
        public HttpResponseMessage CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            }
            else
            {
                try
                {
                    // Add new patient in DataContext and save it in the database
                    db.Patients.Add(patient);
                    db.SaveChanges();

                    return new HttpResponseMessage { StatusCode = HttpStatusCode.Created };
                }
                catch (Exception)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
                }
            }
        }

        // Update a patient based on its id
        [HttpPut]
        public HttpResponseMessage UpdatePatient(int id, Patient patient)
        {
            if (patient == null || id != patient.Id)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            }

            else
            {
                try
                {
                    // retrieve the patient from the database
                    Patient patientToUpdate = db.Patients.Where(x => x.Id == id).FirstOrDefault();
                    if (patientToUpdate != null)
                    {                        
                        patientToUpdate.Title = patient.Title;
                        patientToUpdate.FirstName = patient.FirstName;
                        patientToUpdate.LastName = patient.LastName;
                        patientToUpdate.Age = patient.Age;
                        patientToUpdate.NumberOfEmbryos = patient.NumberOfEmbryos;

                        // save updated patient in the database
                        db.SaveChanges();

                        return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                    }
                    else
                    {
                        return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
                    }
                }
                catch (Exception)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
                }
            }
        }

        // Delete a patient based on its id
        [HttpDelete]
        public HttpResponseMessage DeletePatient(int id)
        {
            try
            {
                Patient patientToDelete = db.Patients.Where(x => x.Id == id).FirstOrDefault();
                if (patientToDelete != null)
                {
                    db.Patients.Remove(patientToDelete);
                    db.SaveChanges();
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                }
                else
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest};
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
            }
        }
    }
}