using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    internal class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            Doctor doctor1 = new Doctor(1, "Doctor1", "Spec1");
            Doctor doctor2 = new Doctor(2, "Doctor2", "Spec2");
            Doctor doctor3 = new Doctor(3, "Doctor3", "Spec3");

            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);
            hospital.AddDoctor(doctor3);

            Patient patient1 = new Patient(1, "Patient1", 21);
            Patient patient2 = new Patient(2, "Patient1", 22);
            Patient patient3 = new Patient(3, "Patient1", 23);

            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);
            hospital.RegisterPatient(patient3);

            HospitalRoom room1 = new HospitalRoom(1, 2);
            HospitalRoom room2 = new HospitalRoom(2, 3);
            HospitalRoom room3 = new HospitalRoom(3, 1);
        
            hospital.CreateRoom(room1);
            hospital.CreateRoom(room2);
            hospital.CreateRoom(room3);

            hospital.HospitalizePatient(1, 1);
            hospital.HospitalizePatient(2, 1);
            hospital.HospitalizePatient(3, 3);

            MedicalRecord record1 = new MedicalRecord(patient1, doctor1, DateTime.Now, "Desc1");
            MedicalRecord record2 = new MedicalRecord(patient2, doctor2, DateTime.Now, "Desc2");
            MedicalRecord record3 = new MedicalRecord(patient3, doctor3, DateTime.Now, "Desc3");
      
            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);
            hospital.AddMedicalRecord(record3);

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            Console.WriteLine(hospital.GetStatistics());
        }

    }
}
